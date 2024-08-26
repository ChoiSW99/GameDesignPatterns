using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visitor
{
    public class BikeEngine : MonoBehaviour, IVisitableElement
    {
        public ItemType type { get; set; } = ItemType.Engine;

        public float turboBoost = 25f;
        public float maxTurboBoost = 200f;

        private bool _isTurboOn;
        private float _defaultSpeed = 300f;
        public float CurrentSpeed
        {
            get
            {
                if (_isTurboOn)
                    return _defaultSpeed + turboBoost;
                return _defaultSpeed;
            }
        }

        public void ToggleTurbo()
        {
            _isTurboOn = !_isTurboOn;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(125, 20, 200, 20), "Turbo Boost: " + turboBoost);
        }
    }
}

