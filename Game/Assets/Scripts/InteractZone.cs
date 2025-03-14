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
        Road road = other.GetComponent<Road>();

        if (road != null)
        {
            road.Activate();
        }
    }
}
