using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Command
{
    
    public class BikeController : MonoBehaviour
    {
        public enum Direction
        {
            LEFT,
            RIGHT,
        }

        private bool _isTurnOn;
        private float _distance = 1f;

        public void ToggleTurbo()
        {
            _isTurnOn = !_isTurnOn;
            Debug.Log("Turbo Active: "+ _isTurnOn.ToString());
        }

        public void Turn(Direction direction)
        {
            if (direction == Direction.LEFT)
                transform.Translate(Vector3.left * _distance);
            if (direction == Direction.RIGHT)
                transform.Translate(Vector3.right * _distance);
        }

        internal void ResetPosition()
        {
            transform.position = new Vector3(0f,0f,0f);
        }
    }

}
