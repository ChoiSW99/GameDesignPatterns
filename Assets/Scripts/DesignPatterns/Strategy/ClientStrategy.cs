using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Strategy
{
    public class ClientStrategy : MonoBehaviour
    {
        private GameObject _drone;
        private List<IManeuverBehaviour> _components = new List<IManeuverBehaviour> ();

        private void SpawnDrone()
        {
            _drone = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _drone.AddComponent<Drone>();
            _drone.transform.position = Random.insideUnitSphere * 10f;

            ApplyRandomStrategy();
        }

        private void ApplyRandomStrategy()
        {
            _components.Add(_drone.AddComponent<BoppingManeuver>());
            _components.Add(_drone.AddComponent<WeavingManeuver>());
            _components.Add(_drone.AddComponent<FallbackManeuver>());

            int randomIndex = Random.Range(0, _components.Count);
            _drone.GetComponent<Drone>().ApplyStrategy(_components[randomIndex]);
        }

        private void OnGUI()
        {
            if(GUILayout.Button("Spawn Drone"))
            {
                SpawnDrone();
            }
        }
    }

}
