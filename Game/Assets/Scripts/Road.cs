using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Road : MonoBehaviour, IHitable
{
    // 이벤트가 호출되면 이벤트에 등록된 함수들이 호출된다
    [SerializeField] UnityEvent callback;

    public void Activate()
    {
        callback.Invoke();
    }
}
