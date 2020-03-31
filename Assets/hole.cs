using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole : MonoBehaviour
{
    public Transform hole2;

    public GameObject savedPinnBall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            if (other.gameObject != savedPinnBall)
            {
                hole2.GetComponent<hole>().savedPinnBall = other.gameObject;
                other.GetComponent<Rigidbody>().transform.position =
                    new Vector3(hole2.position.x, hole2.position.y + 1, hole2.position.z);
            }
        }
    }
}