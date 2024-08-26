using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visitor
{
    public class BikeShield : MonoBehaviour, IVisitableElement
    {
        public ItemType type { get; set; } = ItemType.Shield;
        public float health = 50f; // percent
        public float Damage(float damage)
        {
            health -= damage;
            return health;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(125, 0, 200, 20), "Sheild Health: " + health);
        }
    }
}
