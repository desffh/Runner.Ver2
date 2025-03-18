using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneryManager : Singleton<SceneryManager>
{
    // T타입으로 클래스 타입이 들어간것임

    [SerializeField] Image screenImage;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public IEnumerator FadeIn()
    {
        Color color = screenImage.color;

        color.a = 1f;
        
        screenImage.gameObject.SetActive(true);

        while(color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;

            screenImage.color = color;

            yield return null;
        }

        screenImage.gameObject.SetActive(false);
    }

    public IEnumerator AsyncLoad(int index)
    {
        screenImage.gameObject.SetActive(true);

        // <asyncOperation.allowSceneActivation>
        // 장면이 준비된 즉시 장면이 활성화되는 것을 허용하는 변수입니다.

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        asyncOperation.allowSceneActivation = false;

        Color color = screenImage.color;

        color.a = 0f;

        // <asyncOperation.isDone>
        // 해당 동작이 완료되었는 지 나타내는 변수입니다.

        // 씬 불러오는 작업이 아직 다 되지 않았다면 
        while(asyncOperation.isDone == false) 
        {
            color.a += Time.deltaTime;
            screenImage.color = color;

            // <asyncOperation.progress>
            // 작업의 진행 상태를 나타내는 변수입니다.

            if(asyncOperation.progress >= 0.9f)
            {
                color.a = Mathf.Lerp(color.a, 1.0f, Time.deltaTime);

                screenImage.color = color;

                if(color.a >= 1.0f)
                {
                    asyncOperation.allowSceneActivation = true;

                    yield break; // 강제로 빠져나오기
                }
            }
            yield return null;
        }
    }


    // 씬이 바뀔때마다 페이드 인 호출
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        StartCoroutine(FadeIn());
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
