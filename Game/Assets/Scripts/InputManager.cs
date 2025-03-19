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
        // 키 입력이 들어오지 않았다면
        if(Input.anyKey == false)
        {
            return;
        }
        // 키 입력이 들어왔다면 이벤트 실행 (등록된 이벤트들 호출)
        if(action != null) 
        {
            action.Invoke();
        }
    }
}
