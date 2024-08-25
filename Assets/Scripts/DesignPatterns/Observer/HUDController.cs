using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Observer
{
    public class HUDController : MonoBehaviour, IObserver
    {
        private bool _isTurboOn;
        private float _currentHealth;
        private BikeController _bikeController;
        public void OnNotify(Subject subject)
        {
            if(_bikeController == null)
                _bikeController = subject.GetComponent<BikeController>();

            if (_bikeController != null)
            {
                _isTurboOn = _bikeController.IsTurboOn;
                _currentHealth = _bikeController.CurrenetHealth;
            }
        }   

        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(50, 50, 100, 200));
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Health: " + _currentHealth);
            GUILayout.EndHorizontal();
            if (_isTurboOn)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Turbo Activated!");
                GUILayout.EndHorizontal();
            }

            if(_currentHealth <= 50.0f)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("WARNING: Low Health");
                GUILayout.EndHorizontal();
            }
            GUILayout.EndArea();

        }

    }
}


