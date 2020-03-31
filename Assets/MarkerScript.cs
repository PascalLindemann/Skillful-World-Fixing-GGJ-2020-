using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkerScript : MonoBehaviour
{

    public Image[] images;

    public int index = 0;
    


    public void fillImage()
    {
        images[index].color = Color.green;
        index++;
    }

    public void reset()
    {
        foreach (var image in images)
        {
            image.color = Color.white;
        }

        index = 0;
    }


    public void setMax(int max)
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (i >= max)
            {
                images[i].enabled = false;
            }
            else
            {
                images[i].enabled = true;
            }
        }
    }
}
