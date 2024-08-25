using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public interface IObserver
    {
        void OnNotify(Subject subject); // Notify 받으면 Observer 업데이트
    }
}
