using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using Unity.VisualScripting;
using UnityEngine;

namespace Visitor
{
    [CreateAssetMenu(fileName ="PowerUp", menuName ="PowerUp")]
    public class PowerUp : ScriptableObject, IVisitor
    {
        [SerializeField]
        private ItemType type = ItemType.None;
        public ItemType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string powerupName;
        public GameObject powerupPrefab;
        public string powerupDescription;

        [Tooltip("Fully heal sheild")]
        public bool healsShield;

        [Range(0f, 50f)]
        [Tooltip("Boost turbo settings up to increments of 50/mph")]
        public float turboBoost;

        [Range(0, 25)]
        [Tooltip("Boost weapon range in increments of up to 25 units")]
        public int weaponRange;

        [Range(0f, 50f)]
        [Tooltip("Boost weapon strength in increments of up to 50%")]
        public float weaponStrength;


        public void Visit(BikeShield bikeShield)
        {
            ShowName();
            if (healsShield)
                bikeShield.health = 100f;
        }

        public void Visit(BikeWeapon bikeWeapon)
        {
            ShowName();
            int range = bikeWeapon.range + weaponRange;

            if (range >= bikeWeapon.maxRange)
                bikeWeapon.range = bikeWeapon.maxRange;
            else
                bikeWeapon.range = range;

            float strength = Mathf.Round(bikeWeapon.strength + weaponStrength / 100);
            if(strength >= bikeWeapon.maxStrength)
                bikeWeapon.strength = bikeWeapon.maxStrength;
            else
                bikeWeapon.strength = strength;
        }

        public void Visit(BikeEngine bikeEngine)
        {
            ShowName();
            float boost = bikeEngine.turboBoost + turboBoost;

            if (boost < 0f)
                bikeEngine.turboBoost = 0f;

            if (boost >= bikeEngine.maxTurboBoost)
                bikeEngine.turboBoost = bikeEngine.maxTurboBoost;
            else
                bikeEngine.turboBoost = boost;
        }
        private void ShowName()
        {
            Debug.Log(powerupName);
        }
    }
}
