using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadline;

    [SerializeField] Rigidbody rigidBody;

    [SerializeField] int positionX =  4;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        OnKeyUpdate();
    }
    private void FixedUpdate()
    {
        rigidbodyMove();
    }


    void OnKeyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadline != RoadLine.LEFT)
            {
                roadline--;

            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadline != RoadLine.RIGHT)
            {
                roadline++;
            }
        }
    }
    void rigidbodyMove()
    {
        rigidBody.position = (new Vector3((int)roadline * positionX, 0, 0));
    }
}
