using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinnBall : MonoBehaviour
{
    private Rigidbody rb;
//    private RigidbodyConstraints constraints;

    private Vector3 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

       // constraints = RigidbodyConstraints.FreezeAll;

        startPos = rb.transform.position;

    }

 


    public void hitTarget(Transform parent)
    {
      //  transform.parent = parent;
      //  transform.localPosition = Vector3.zero;
        rb.transform.position = new Vector3(1000,1000,1000);
    }

    public void doDestroy()
    {
        rb.transform.position = new Vector3(1000,1000,1000);
    }

    public void reset()
    {
        transform.position = startPos;
    }
}
