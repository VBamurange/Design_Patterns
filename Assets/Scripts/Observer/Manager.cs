using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public interface IObserver<T>
    {
        void OnNext(T data);
        void OnError(System.Exception error);
        void OnCompleted();
    }
}
