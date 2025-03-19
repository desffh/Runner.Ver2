using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : Singleton<MouseManager>
{
    [SerializeField] Texture2D texture2D;

    protected override void Awake()
    {
        // 부모 Awake 호출하기 
        base.Awake();
        texture2D = Resources.Load<Texture2D>("Default");
    }

    // Start보다 OnEbalble이 먼저 실행된다
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void State(int state)
    {
        switch(state)
        {
            case 0:
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            break;
            
            case 1:
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

            }
            break;
        }
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        State(scene.buildIndex);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
