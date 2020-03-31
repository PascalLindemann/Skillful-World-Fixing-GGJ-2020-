using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelScript : MonoBehaviour
{

    public int holesFinsihed = 0;
    public int maxHoles = 6;

    public GameController GameController;
    public MarkerScript marker;

    public GameObject plane;
    public pinnBall[] PinbBalls;
    public dropZone[] DropZones;

    public GameObject finishedAnimation;
    
    public void Start()
    {
        marker.setMax(maxHoles);
    }

    public void newHoleFinsihed()
    {
        holesFinsihed++;
        marker.fillImage();
        if (holesFinsihed == maxHoles)
        {
            marker.reset();
            if (finishedAnimation != null)
            {
                finishedAnimation.SetActive(true);
            }
           
            
            GameController.levelFinished();
        }
    }

    public void restart()
    {
        plane.transform.rotation = Quaternion.identity;
        foreach (var pinnBall in PinbBalls)
        {
            pinnBall.reset();
        }

        foreach (var dropZone in DropZones)
        {
            dropZone.reset();
        }

        marker.reset();
        holesFinsihed = 0;
    }
}
