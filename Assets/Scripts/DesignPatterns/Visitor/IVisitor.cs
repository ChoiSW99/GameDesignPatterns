using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Visitor
{
    public interface IVisitor
    {
        ItemType Type { get; set; }

        public void Visit(BikeEngine bikeEngine);
        public void Visit(BikeShield bikeShield);
        public void Visit(BikeWeapon bikeWeapon);
    }

}
