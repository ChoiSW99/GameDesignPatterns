using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public class CameraController : MonoBehaviour, IObserver
    {
        private bool _isTurboOn;
        private Vector3 _initialPosition;
        private float _shakeMagnitude = 0.1f;
        private BikeController _bikeController;

        private void OnEnable()
        {
            _initialPosition = transform.localPosition;
        }

        private void Update()
        {
            if (_isTurboOn)
            {
                transform.localPosition = _initialPosition + (Random.insideUnitSphere * _shakeMagnitude);
            }
            else
            {
                transform.localPosition = _initialPosition;
            }
        }

        public void OnNotify(Subject subject)
        {
            if(_bikeController == null)
                _bikeController = subject.GetComponent<BikeController>();

            if( _bikeController != null )
                _isTurboOn = _bikeController.IsTurboOn;
        }

    }
}

