using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropZone : MonoBehaviour
{
    public bool full = false;

    public GameObject filling;

    public levelScript LevelScript;

    private void OnTriggerEnter(Collider other)
    {
        
        if (!full)
        {
            if (other.gameObject.GetComponent<pinnBall>() != null)
            {
                other.gameObject.GetComponent<pinnBall>().doDestroy();
                other.gameObject.GetComponent<pinnBall>().hitTarget(gameObject.transform);
                gameObject.GetComponent<dropZone>().enabled = false;
                filling.SetActive(true);
                GetComponent<AudioSource>().Play();
                full = true;
                LevelScript.newHoleFinsihed();
            }
        }
    }

    public void reset()
    {
        full = false;
        gameObject.GetComponent<dropZone>().enabled = true;
        filling.SetActive(false);
        
    }
    
    
}