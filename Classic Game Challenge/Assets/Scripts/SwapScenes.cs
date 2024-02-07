using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SwapScenes : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
            BGmusic.instance.GetComponent<AudioSource>().Pause();
            //BGmusic.instance.GetComponent<AudioSource>().Play();
    }
}