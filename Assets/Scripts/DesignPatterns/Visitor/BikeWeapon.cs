using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visitor
{
    public class BikeWeapon : MonoBehaviour, IVisitableElement
    {
        public ItemType type { get; set; } = ItemType.Weapon;

        [Header("Range")]
        public int range = 5;
        public int maxRange = 25;
        [Header("Strength")]
        public float strength = 25f;
        public float maxStrength = 50f;


        public void Fire()
        {
            Debug.Log("Weapon Fired!");
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        private void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(125, 40, 200, 20), "Weapon Range: " + range);
            GUI.Label(new Rect(125, 60, 200, 20), "Weapon Strength: " + strength);
        }
    }

}
