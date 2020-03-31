using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector3 = UnityEngine.Vector3;

public class bug : MonoBehaviour
{
    private Rigidbody rb;

    public Vector3 point1;
    public Vector3 point2;

    public Vector3 targetVector;

    public float movmentSpeed;

    public int currentPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        //  rb = GetComponent<Rigidbody>();

        point1 = transform.TransformPoint(point1);
        point2 = transform.TransformPoint(point2);
    }

    private void FixedUpdate()
    {
        //  rb.velocity = Vector3.zero;
        //  rb.MovePosition(Vector3.MoveTowards(rb.position, getTarget(), movmentSpeed));
        transform.position = Vector3.MoveTowards(transform.position, transform.forward * 1000, movmentSpeed);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5000))
        {
            if (hit.transform.gameObject.CompareTag("wall"))
            {
                if (hit.distance < 0.8f)
                {
                    transform.Rotate(new Vector3(0, 180, 0));
                }
            }
        }
        
    }

    private void Update()
    {
        if (Vector3.MoveTowards(transform.position, getTarget(), movmentSpeed) == Vector3.zero)
        {
            currentPoint = (currentPoint + 1) % 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger");
        if (other.CompareTag("bug_point"))
        {
            print("bug");
            currentPoint = (currentPoint + 1) % 2;
        }
    }

    private Vector3 getTarget()
    {
        if (currentPoint == 0)
        {
            return point1;
        }

        return point2;
    }

    public void setPoint()
    {
        currentPoint = (currentPoint + 1) % 2;
        print("neuer point");
    }
}