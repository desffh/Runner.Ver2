using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool checks = true;
    public bool check
    {
        get { return checks;  }
        set { checks = value; }
    }

    public void Execute()
    {
        check = true;
    }

    public void Finish()
    {
        check = false;

        MouseManager.Instance.State(0);
    }
}
