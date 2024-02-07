using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
     public AudioSource audioplayer; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioplayer.Play();
            Destroy(gameObject);
        }
    }
}
