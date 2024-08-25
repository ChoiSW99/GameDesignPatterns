using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Observer
{
    public class ClientObserver : MonoBehaviour
    {
        private BikeController _bikeController;
        private void Start()
        {
            _bikeController = FindObjectOfType<BikeController>();
        }

        private void OnGUI()
        {
            if(GUILayout.Button("Damage Bike"))
            {
                if(_bikeController != null)
                {
                    _bikeController.TakeDamage(15.0f);
                }
            }
            if (GUILayout.Button("Toggle Turbo"))
            {
                if (_bikeController != null)
                {
                    _bikeController.ToggleTurbe();
                }
            }

        }
    }

}
