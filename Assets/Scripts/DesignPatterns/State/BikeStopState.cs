using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public class BikeStopState : MonoBehaviour, IBikeState
    {
        BikeController _bikeController;
        public void Handle(BikeController bikeController)
        {
            if (!_bikeController)
                _bikeController = bikeController;
            _bikeController.CurrentSpeed = 0;
        }
    }

}
