using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugPoint : MonoBehaviour
{

    public int point;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bug"))
        {
            other.GetComponent<bug>().setPoint();
            print("trigger");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bug"))
        {
            other.gameObject.GetComponent<bug>().setPoint();
            print("trigger");
        }
    }
}
