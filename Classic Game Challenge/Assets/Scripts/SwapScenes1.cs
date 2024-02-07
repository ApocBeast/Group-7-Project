using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SwapScenes1 : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
            BGmusic.instance.GetComponent<AudioSource>().Pause();
            //BGmusic.instance.GetComponent<AudioSource>().Play();
    }
}