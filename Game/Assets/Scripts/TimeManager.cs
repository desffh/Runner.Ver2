using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField] float activetime = 2.5f;

    [SerializeField] float limittime = 0.5f;

    // �б� ���� 
    public float activeTime { get { return activetime; } }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    IEnumerator Decrease()
    {
        while(GameManager.Instance.State && activeTime > limittime)
        {
            yield return CoroutineCache.WaitForSeconds(5.0f);

            activetime -= 0.25f;
        }
    }

    // ���Ӿ�(1)�� Ȱ��ȭ �Ǹ� �Լ� ����
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        activetime = 2.5f;

        if (scene.buildIndex == 1)
        {
            StartCoroutine(Decrease());
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
}
