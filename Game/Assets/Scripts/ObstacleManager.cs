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
            // ResourcesManager

            GameObject prefab = 
                ResourcesManager.Instance.
                Instantiate(obstacleNames[Random.Range(0, obstacleNames.Count)], gameObject.transform);

            prefab.SetActive(false);

            obstacles.Add(prefab);

        }
    }


    // 하나라도 비활성화가 있다면 false 반환
    public bool Check()
    {
        for(int i = 0; i < obstacles.Count; i++) 
        {
            if (obstacles[i].activeSelf == false)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator ActiveObstacle()
    {
        while(GameManager.Instance.State)
        {
            yield return new WaitForSeconds(2.5f);

            random = Random.Range(0, obstacles.Count);

            // 현재 게임 오브젝트가 활성화되어 있는 지 확인합니다.
            while (obstacles[random].activeSelf == true)
            {
                // 현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는 지 확인합니다.
                
                if(Check() == true)
                {
                    // 모든 게임 오브젝트가 활성화되어 있다면 게임 오브젝트를 새로 생성한 다음
                    // obstacles 리스트에 넣어줍니다.


                    // ResourcesManager

                    GameObject clone = 
                        ResourcesManager.Instance.
                        Instantiate(obstacleNames[Random.Range(0, obstacleNames.Count)], gameObject.transform);
                    

                    clone.SetActive(false);

                    obstacles.Add(clone);
                }

                // 현재 인덱스에 있는 게임 오브젝트가 활성화되어 있으면 
                // random 변수의 값을 +1을 해서 다시 검색합니다.
                random = (random + 1) % obstacles.Count;
            } 
            
            obstacles[random].SetActive(true);
        }
    }
}
