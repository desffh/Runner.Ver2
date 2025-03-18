using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    // 다른곳에서 접근하려면 public
    public static T Instance
    {
        get { return instance; }
    }

    protected virtual void Awake()
    {
        if(instance == null) 
        {
            instance = (T)FindAnyObjectByType(typeof(T)); // 게임 오브젝트 타입 T
           
            DontDestroyOnLoad(instance);
        }
        else
        {
            // 이미 있다면 자신의 게임 오브젝트 파괴
            Destroy(gameObject);

            return;
        }

        DontDestroyOnLoad(instance.gameObject);
    }

    
}
