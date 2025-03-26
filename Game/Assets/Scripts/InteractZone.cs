using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class InteractZone : MonoBehaviour
{
    [SerializeField] BoxCollider Collider;

    private void Awake()
    {
        Collider = GetComponent<BoxCollider>();
    }

    public void OnTriggerEnter(Collider other)
    {
        // ���� ��� ��Ģ

        IHitable hitable = other.GetComponent<IHitable>();
        
        if (hitable != null)
        {
            hitable.Activate();
        }
    }


}
