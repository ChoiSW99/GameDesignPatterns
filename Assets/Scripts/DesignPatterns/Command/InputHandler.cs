using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command
{
    public class InputHandler : MonoBehaviour
    {
        private Invoker _invoker;
        private bool _isReplaying;
        private bool _isRecording;
        private BikeController _bikeController;
        private Command _buttonA, _buttonD, _buttonW;

        private void Start()
        {
            _invoker = gameObject.AddComponent<Invoker>();
            _bikeController = gameObject.AddComponent<BikeController>();

            // 커맨드의 생성자가 BikeController의 인스턴스를 전달한다
            _buttonA = new TurnLeft(_bikeController); 
            _buttonD = new TurnRight(_bikeController);
            _buttonW = new ToggleTurbo(_bikeController);
        }

        private void Update()
        {
            if(!_isReplaying && _isRecording)
            {
                if (Input.GetKeyUp(KeyCode.A))
                    _invoker.Execute(_buttonA);
                if (Input.GetKeyUp(KeyCode.D))
                    _invoker.Execute(_buttonD);
                if (Input.GetKeyUp(KeyCode.W))
                    _invoker.Execute(_buttonW);
            }
        }

        // 테스트용 코드
        private void OnGUI()
        {
            if(GUILayout.Button("Start Recording"))
            {
                _bikeController.ResetPosition();
                _isReplaying = false;
                _isRecording = true;
                _invoker.Record();
            }

            if (GUILayout.Button("Stop Recording"))
            {
                _bikeController.ResetPosition();
                _isRecording = false;
            }

            if (!_isRecording)
            {
                if (GUILayout.Button("Start Replay"))
                {
                    _bikeController.ResetPosition();
                    _isRecording = false;
                    _isReplaying = true;
                    _invoker.Replay();
                }
            }

        }
    }

}
