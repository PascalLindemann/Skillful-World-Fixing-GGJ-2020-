using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public levelScript[] levels;
    public int index = 0;

    public Camera camera;

    public GameObject text;

    public void levelFinished()
    {
        Time.timeScale = 0;
        StartCoroutine(WaitCoroutine());
    /*    levels[index].gameObject.SetActive(false);
        index++;
        levels[index].gameObject.SetActive(true);
        camera.GetComponent<Animator>().enabled = true;*/
    Time.timeScale = 1;
    }

    IEnumerator  WaitCoroutine()
    {
        yield return new WaitForSeconds(2);
        
        index++;
        if (levels.Length >= index+1)
        {
            levels[index].gameObject.SetActive(true);
        }
        else
        {
            text.SetActive(true);
        }
        camera.GetComponent<Animator>().SetTrigger(""+index);
        yield return new WaitForSeconds(2);
        levels[index-1].gameObject.SetActive(false);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      //  levels[index].restart();
    }
    
}
