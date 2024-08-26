using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visitor
{
    public class PickUp : MonoBehaviour
    {
        public PowerUp powerUp;

        private void OnTriggerEnter(Collider other)
        {
            BikeController bikeController;
            if (other.TryGetComponent<BikeController>(out bikeController))
            {
                bikeController.Accept(powerUp);
                Destroy(gameObject);
            }
        }
    }

}

