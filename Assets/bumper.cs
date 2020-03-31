using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumper : MonoBehaviour
{

    public float force = 50;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        
        GetComponent<AudioSource>().Play();
        
        Vector3 forceVector = (other.transform.position - transform.position);
        
        other.gameObject.GetComponent<Rigidbody>().AddForce(forceVector*force,ForceMode.Impulse);
      //  other.rigidbody.AddRelativeForce(forceVector * force,ForceMode.Impulse);
        
      
      
    }
}
