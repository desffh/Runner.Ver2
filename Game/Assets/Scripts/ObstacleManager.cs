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


    // �ϳ��� ��Ȱ��ȭ�� �ִٸ� false ��ȯ
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

            // ���� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
            while (obstacles[random].activeSelf == true)
            {
                // ���� ����Ʈ�� �ִ� ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִ� �� Ȯ���մϴ�.
                
                if(Check() == true)
                {
                    // ��� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� �ִٸ� ���� ������Ʈ�� ���� ������ ����
                    // obstacles ����Ʈ�� �־��ݴϴ�.


                    // ResourcesManager

                    GameObject clone = 
                        ResourcesManager.Instance.
                        Instantiate(obstacleNames[Random.Range(0, obstacleNames.Count)], gameObject.transform);
                    

                    clone.SetActive(false);

                    obstacles.Add(clone);
                }

                // ���� �ε����� �ִ� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� ������ 
                // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.
                random = (random + 1) % obstacles.Count;
            } 
            
            obstacles[random].SetActive(true);
        }
    }
}
