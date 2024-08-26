using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Strategy
{
    public interface IManeuverBehaviour 
    {
        void Maneuver(Drone drone);
    }
}
