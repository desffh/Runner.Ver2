using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{

    [SerializeField] Text buttontext;

    private void Awake()
    {
        buttontext = GetComponentInChildren<Text>();       
    }


    public void OnEnter()
    {
        buttontext.fontSize = 80;
    }

    public void OnExit()
    {
        buttontext.fontSize = 65;
    }

    public void OnSelect()
    {
        buttontext.fontSize = 50;
    }

 
}
