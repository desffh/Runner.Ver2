using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;


    [SerializeField] float offset = 40;

    [SerializeField] float speed;

    private void Start()
    {
    }
    void Update()
    {
        if (GameManager.Instance.check == false)
        {
            return;
        }

        for (int i = 0; i < roads.Count; i++) 
        {
            roads[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    // 위치 변경 함수 (이벤트)
    public void InitializePosition()
    {
        GameObject newroad = roads[0];

        Transform fourth = roads[3].GetComponent<Transform>();

        roads.Remove(newroad);
        
        float newZ = roads[roads.Count - 1].transform.position.z + offset;

        newroad.transform.position = new Vector3(0, 0, newZ);

        roads.Add(newroad);

        Debug.Log("InitializePosition");
    }
}
