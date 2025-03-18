using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    // �ٸ������� �����Ϸ��� public
    public static T Instance
    {
        get { return instance; }
    }

    protected virtual void Awake()
    {
        if(instance == null) 
        {
            instance = (T)FindAnyObjectByType(typeof(T)); // ���� ������Ʈ Ÿ�� T
           
            DontDestroyOnLoad(instance);
        }
        else
        {
            // �̹� �ִٸ� �ڽ��� ���� ������Ʈ �ı�
            Destroy(gameObject);

            return;
        }

        DontDestroyOnLoad(instance.gameObject);
    }

    
}
