using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IHitable
{
    [SerializeField] float speed;

    public void Activate()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.State == false)
        {
            return;
        }

        // 장애물은 리지드 바디가 없기 때문에 일반 업데이트에서 이동

        transform.Translate(Vector3.back * SpeedManager.Instance.Speed * Time.deltaTime);
    
    
    }



}
