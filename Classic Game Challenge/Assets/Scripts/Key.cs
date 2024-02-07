using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Key : MonoBehaviour

{ 
    public AudioClip collectedClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            controller.keySound();
            Destroy(gameObject);
            
            controller.PlaySound(collectedClip);
            
        }
    }
}
