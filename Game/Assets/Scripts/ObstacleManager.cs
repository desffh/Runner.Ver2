using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List <GameObject> obstacles;

    [SerializeField] List<string> obstacleNames;

    [SerializeField] int createCount = 5;

    [SerializeField] int random;

    void Start()
    {
        obstacles.Capacity = 10;

        Create();

        StartCoroutine(ActiveObstacle());
    }

    public void Create()
    {
        for(int i = 0; i < createCount; i++)
        {
            GameObject prefab = 
                Instantiate(Resources.Load<GameObject>(obstacleNames[Random.Range(0, obstacleNames.Count)]), gameObject.transform);

            prefab.SetActive(false);

            obstacles.Add(prefab);

        }
    }

    IEnumerator ActiveObstacle()
    {
        int count = 0;

        while(true)
        {
            if(count >= obstacles.Count)
            {
                yield break;
            }

            yield return new WaitForSeconds(2.5f);

            random = Random.Range(0, obstacles.Count);

            while (obstacles[random].activeSelf == true)
            {
                random = (random + 1) % obstacles.Count;
            } 
            
            obstacles[random].SetActive(true);
            
            count++;
        }
    }
}
