using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atom : MonoBehaviour
{
    private Rigidbody rb;

    public float maxScale = 2;

    public float minScale = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        maxScale = maxScale * transform.localScale.x;
        minScale = minScale * transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
