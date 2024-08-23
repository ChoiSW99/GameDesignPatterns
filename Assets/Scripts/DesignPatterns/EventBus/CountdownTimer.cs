using EventBus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventBus
{
    public class CountdownTimer : MonoBehaviour
    {
        private float _currentTime;
        private float duration = 3.0f;

        private void OnEnable()
        {
            // 오브젝트가 활성화될 때마다, Subscribe()가 호출된다.
            // 즉, 오브젝트가 활성화되었을 때, 구독중이기에 이벤트를 수신한다.
            RaceEventBus.Subscribe(RaceEventType.COUNTDOWN, StartTimer);
        }

        private void OnDisable()
        {
            // 오브젝트가 활성화되면, 구독취소하여, 이벤트를 수신받지 않는다.
            RaceEventBus.Unsubscribe(RaceEventType.COUNTDOWN, StartTimer);
        }

        private void StartTimer()
        {
            StartCoroutine(Countdown()); // 코루틴은 Disable되면, 없어진다.
        }

        IEnumerator Countdown()
        {
            _currentTime = duration;
            while (_currentTime > 0)
            {
                yield return new WaitForSeconds(1f);
                _currentTime--;
            }

            RaceEventBus.Publish(RaceEventType.START);
        }

        private void OnGUI()
        {
            GUI.color = Color.blue;
            GUI.Label(new Rect(125, 0, 100, 20), "COUNTDOWN: " + _currentTime);
        }
    }

}
