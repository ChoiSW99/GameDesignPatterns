using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Command
{
    public class TurnLeft : Command
    {
        private BikeController _bikeController;

        public TurnLeft(BikeController bikeController)
        {
            _bikeController = bikeController;
        }


        public override void Execute()
        {
            _bikeController.Turn(BikeController.Direction.LEFT);
        }
    }

}
