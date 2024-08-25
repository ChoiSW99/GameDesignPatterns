using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public class BikeController : Subject
    {
        private bool _isEngineOn;
        private HUDController _hudController;
        private CameraController _cameraController;

        public bool IsTurboOn { get; private set; }

        [SerializeField] 
        private float health = 100.0f;
        public float CurrenetHealth { get { return health; } }

        private void Awake()
        {
            _hudController = GetComponent<HUDController>();
            _cameraController = FindObjectOfType<CameraController>();
        }

        private void Start()
        {
            StartEngine();
        }

        private void OnEnable()
        {
            if (_hudController != null)
                Attach(_hudController);

            if (_cameraController!= null)
                Attach(_cameraController);
        }

        private void OnDisable()
        {
            if (_hudController != null)
                Detach(_hudController);

            if (_cameraController != null)
                Detach(_cameraController);
        }

        private void StartEngine()
        {
            _isEngineOn = true;
            Notify();
        }

        public void ToggleTurbe()
        {
            if(_isEngineOn)
                IsTurboOn = !IsTurboOn;
            Notify();
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            IsTurboOn = false;
            Notify();
            if (health < 0)
                Destroy(gameObject);
        }
    }
}

