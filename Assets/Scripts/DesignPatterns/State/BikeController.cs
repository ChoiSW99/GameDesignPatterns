using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace StatePattern
{
    public enum Direction
    {
        Left = -1,
        Right = 1
    }

    public class BikeController : MonoBehaviour
    {
        public float maxSpeed = 2.0f;
        public float turnDistance = 2.0f;
        public float CurrentSpeed { get; set; }
        public Direction CurrentTurnDirection
        {
            get; private set;
        }

        private IBikeState _startState, _stopState, _turnState;

        private BikeStateContext _bikestateContext;

        private void Start()
        {
            _bikestateContext = new BikeStateContext(this);
            _startState = gameObject.AddComponent<BikeStartState>();
            _stopState = gameObject.AddComponent<BikeStopState>();
            _turnState = gameObject.AddComponent<BiketurnState>();

            _bikestateContext.Transition(_stopState);
        }

        public void StartBike()
        {
            _bikestateContext.Transition(_startState);
        }

        public void StopBike()
        {
            _bikestateContext.Transition(_stopState);
        }

        public void TurnBike(Direction direction)
        {
            CurrentTurnDirection = direction;
            _bikestateContext.Transition(_turnState);
        }
    }

}