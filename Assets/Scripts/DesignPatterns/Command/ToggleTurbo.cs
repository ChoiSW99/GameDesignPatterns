using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class ToggleTurbo : Command
    {
        private BikeController _bikeController;

        public ToggleTurbo(BikeController bikeController)
        {
            _bikeController = bikeController;
        }

        public override void Execute()
        {
            _bikeController.ToggleTurbo();
        }
    }
}