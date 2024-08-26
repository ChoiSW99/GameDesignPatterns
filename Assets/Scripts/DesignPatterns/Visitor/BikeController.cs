using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Visitor
{
    public class BikeController : MonoBehaviour, IVisitableElement
    {
        public ItemType type { get; set; } = ItemType.None;

        private List<IVisitableElement> _bikeElements = new List<IVisitableElement>();

        private void Start()
        {
            _bikeElements.Add(gameObject.AddComponent<BikeEngine>());
            _bikeElements.Add(gameObject.AddComponent<BikeShield>());
            _bikeElements.Add(gameObject.AddComponent<BikeWeapon>());
        }
        
        public void Accept(IVisitor visitor)
        {
            foreach(IVisitableElement element in _bikeElements)
            {
                if(element.type == visitor.Type)
                    element.Accept(visitor);
            }
        }
    }
}
