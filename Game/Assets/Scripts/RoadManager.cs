using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;

    [SerializeField] float speed;

    void Start()
    {
        Debug.Log(roads.Capacity);
    }

    void Update()
    {
        for(int i = 0; i < roads.Count; i++) 
        {
            roads[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
