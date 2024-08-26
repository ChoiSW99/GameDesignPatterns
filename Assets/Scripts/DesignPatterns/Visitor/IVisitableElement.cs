using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visitor
{
    public enum ItemType
    {
        None,
        Engine,
        Shield,
        Weapon
    }
    public interface IVisitableElement
    {
        ItemType type { get; set; }

        public void Accept(IVisitor visitor);
    }
}
