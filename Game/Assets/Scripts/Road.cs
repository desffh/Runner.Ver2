using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Road : MonoBehaviour
{
    // �̺�Ʈ�� ȣ��Ǹ� �̺�Ʈ�� ��ϵ� �Լ����� ȣ��ȴ�
    [SerializeField] UnityEvent callback;

    public void Activate()
    {
        callback.Invoke();
    }
}
