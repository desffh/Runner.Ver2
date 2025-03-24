using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{   

    // 제네릭 타입
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>(path);

        if(prefab == null)
        {
            Debug.Log("Failed to Load Prefab : " + path);
            return null;
        }

        GameObject clone = Object.Instantiate(prefab, parent);

        // 읽기전용이라 대입해야된다
        clone.name = clone.name.Replace("(Clone)", "");

        return clone;
    }
}
