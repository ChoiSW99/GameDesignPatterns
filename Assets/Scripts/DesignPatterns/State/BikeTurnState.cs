using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class BiketurnState : MonoBehaviour, IBikeState
    {
        Vector3 _turnDirection;
        BikeController _bikeController;

        public void Handle(BikeController bikeController)
        {
            if(!_bikeController)
                _bikeController = bikeController;

            _turnDirection.x = (float)_bikeController.CurrentTurnDirection;

            if(_bikeController.CurrentSpeed > 0)
                transform.Translate(_turnDirection * _bikeController.turnDistance);
        }
    }

}
