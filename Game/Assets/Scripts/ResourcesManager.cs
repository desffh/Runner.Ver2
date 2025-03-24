using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{   

    // ���׸� Ÿ��
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    // Instantiate ����
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>(path);

        if(prefab == null)
        {
            Debug.Log("Failed to Load Prefab : " + path);
            return null;
        }

        // Object�� ��������
        // ������ prefab ��ü�� ��ȯ�ϱ� ���ؼ� �������� clone�� ���
        GameObject clone = Object.Instantiate(prefab, parent);

        // �б������̶� �����ؾߵȴ�
        clone.name = clone.name.Replace("(Clone)", "");

        return clone;
    }
}
