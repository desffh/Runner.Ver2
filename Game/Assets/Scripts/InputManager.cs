using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using System;

public class InputManager : Singleton<InputManager>
{
    public Action action;

    

    void Start()
    {
        
    }

    
    void Update()
    {
        // Ű �Է��� ������ �ʾҴٸ�
        if(Input.anyKey == false)
        {
            return;
        }
        // Ű �Է��� ���Դٸ� �̺�Ʈ ���� (��ϵ� �̺�Ʈ�� ȣ��)
        if(action != null) 
        {
            action.Invoke();
        }
    }
}
