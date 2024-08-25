using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Observer
{
    public abstract class Subject : MonoBehaviour
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach(IObserver observer in _observers)
            {
                observer.OnNotify(this);
            }
        }
    }

}

