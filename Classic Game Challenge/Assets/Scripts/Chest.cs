using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{ 
    public AudioClip collectedClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        //if (other.gameObject.tag == "Player")
        //{
        //    chestSound();
        //    Destroy(gameObject);
        //}
        if (controller != null)
        {
            controller.chestSound();
            Destroy(gameObject);
            
            controller.PlaySound(collectedClip);
            
        }
    }
}
