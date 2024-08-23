using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    public interface IBikeState
    {
        void Handle(BikeController bikeController);
    }
}