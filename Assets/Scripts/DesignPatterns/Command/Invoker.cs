using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Command
{
    /// <summary>
    /// 커맨드 객체를 호출하는 역할을 합니다. command.Execute();
    /// 보통 클라이언트가 이 객체에 커맨드를 전달하고, 인보커는 필요할 때 execute() 메서드를 호출하여 커맨드를 실행합니다.
    /// </summary>
    public class Invoker : MonoBehaviour
    {
        private bool _isRecording;
        private bool _isReplaying;
        private float _replayTime;
        private float _recordingTime; 
        private SortedList<float, Command> _recordedCommands = new SortedList<float, Command>();

        // Command 기록
        public void Execute(Command command)
        {
            command.Execute();

            if (_isRecording)
                _recordedCommands.Add(_recordingTime, command);

            Debug.Log("Recorded Time : " + _recordingTime);
            Debug.Log("Recorded Command : " + command);
        }

        public void Record()
        {
            _recordingTime = 0f;
            _isRecording = true;
        }

        public void Replay()
        {
            _replayTime = 0f;
            _isReplaying = true;

            if (_recordedCommands.Count <= 0)
                Debug.LogError("No commands to replay!");

            _recordedCommands.Reverse();
        }

        private void FixedUpdate()
        {
            if (_isRecording)
                _recordingTime += Time.fixedDeltaTime;

            if (_isReplaying)
            {
                _replayTime += Time.deltaTime;

                if (_recordedCommands.Any())
                {
                    if(Mathf.Approximately(_replayTime, _recordedCommands.Keys[0]))
                    {
                        Debug.Log("Replay Time : " + _replayTime);
                        Debug.Log("Replay Command : " + _recordedCommands.Keys[0]);

                        _recordedCommands.Values[0].Execute();
                        _recordedCommands.RemoveAt(0);
                    }
                }
                else
                {
                    _isReplaying = false;
                }
            }
        }

    }
}
