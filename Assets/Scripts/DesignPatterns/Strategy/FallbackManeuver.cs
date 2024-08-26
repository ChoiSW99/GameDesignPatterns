using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Strategy
{
    public class FallbackManeuver : MonoBehaviour, IManeuverBehaviour
    {
        public void Maneuver(Drone drone)
        {
            StartCoroutine(Fallback(drone));
        }

        IEnumerator Fallback(Drone drone)
        {
            float time = 0f;
            float speed = drone.speed;
            Vector3 startPosition = drone.transform.position;
            Vector3 endPosition = new Vector3(startPosition.x, startPosition.y, drone.fallbackDistance);

            while (time < speed)
            {
                drone.transform.position = Vector3.Lerp(startPosition, endPosition, time / speed);
                time += Time.deltaTime;
                yield return null;
            }
        }
    }
}
