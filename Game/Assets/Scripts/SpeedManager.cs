using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedManager : Singleton<SpeedManager>
{
    [SerializeField] float speed = 30;

    [SerializeField] float limitspeed = 60.0f;
    public float Speed { get { return speed; } }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    public IEnumerator Increase()
    {
        while(GameManager.Instance.State && speed < limitspeed)
        {
            yield return CoroutineCache.WaitForSeconds(5.0f);

            speed += 2.5f;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        speed = 30f;

        if(scene.buildIndex == 1)
        {
            StartCoroutine(Increase()); 
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
}
