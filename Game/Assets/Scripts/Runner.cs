using System.Collections;
using System.Collections.Generic;
using Cinemachine;
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

    [SerializeField] Animator animator;

    [SerializeField] int positionX =  4;

    [SerializeField] CinemachineVirtualCamera CinemachineVirtualCamera;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        InputManager.Instance.action += OnKeyUpdate;
    }
    private void FixedUpdate()
    {
        if(GameManager.Instance.State == false)
        {
            return;
        }

        rigidbodyMove();
    }

    private void Update()
    {
        
        
    }


    void OnKeyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadline != RoadLine.LEFT)
            {
                roadline--;
                animator.Play("LeftAvoid");
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadline != RoadLine.RIGHT)
            {
                roadline++;
                animator.Play("RightAvoid");
            }
        }
    }
    void rigidbodyMove()
    {

        rigidBody.position =
            Vector3.Lerp
            (
                rigidBody.position,
                new Vector3((int)roadline * positionX, 0, 0),
                Time.deltaTime * SpeedManager.Instance.Speed
            );
    }

    void Die()
    {
        animator.Play("Die");
        GameManager.Instance.Finish();
        CinemachineVirtualCamera.LookAt = transform;
    }

    private void OnTriggerEnter(Collider other)
    {   
        // 충돌된 오브젝트에 Obstacle 스크립트
        Obstacle obstacle = other.GetComponent<Obstacle>();

        if (obstacle != null)
        {
            Die();
        }
    }


    public void synchronize()
    {
        animator.speed = SpeedManager.Instance.Speed / SpeedManager.Instance.InitializeSpeed;
    }

    private void Disable()
    {
        InputManager.Instance.action -= OnKeyUpdate;
    }
}

