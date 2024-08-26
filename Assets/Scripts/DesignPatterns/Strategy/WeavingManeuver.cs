using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Strategy
{
    public class WeavingManeuver : MonoBehaviour, IManeuverBehaviour
    {
        public void Maneuver(Drone drone)
        {
            StartCoroutine(Weave(drone));
        }

        IEnumerator Weave(Drone drone)
        {
            float time;
            bool isReverse = false;
            float speed = drone.speed;
            Vector3 startPosition = drone.transform.position;
            Vector3 endPosition = new Vector3(drone.weavingDistance, startPosition.y, startPosition.z);

            while (true)
            {
                time = 0f;
                Vector3 start = drone.transform.position;
                Vector3 end = isReverse ? startPosition : endPosition;

                while (time < speed)
                {
                    drone.transform.position = Vector3.Lerp(start, end, time / speed);
                    time += Time.deltaTime;
                    yield return null;
                }

                yield return new WaitForSeconds(1f);
                isReverse = !isReverse;
            }
        }
    }

}
