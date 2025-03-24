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

    // Instantiate 랩핑
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>(path);

        if(prefab == null)
        {
            Debug.Log("Failed to Load Prefab : " + path);
            return null;
        }

        // Object는 생략가능
        // 생성된 prefab 객체를 반환하기 위해서 참조변수 clone에 담기
        GameObject clone = Object.Instantiate(prefab, parent);

        // 읽기전용이라 대입해야된다
        clone.name = clone.name.Replace("(Clone)", "");

        return clone;
    }
}
