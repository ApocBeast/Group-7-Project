using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController inventory = other.gameObject.GetComponent<PlayerController>();
        if (other.gameObject.tag == "Player")
        {
            if(inventory.keyCount == 2)
            {
                Destroy(gameObject);
            }
        }
    }
}
