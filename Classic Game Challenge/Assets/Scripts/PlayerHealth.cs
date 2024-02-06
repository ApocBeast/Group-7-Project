using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f; 
    [SerializeField] private float maxHealth = 2000f; 

    // Start is called before the first frame update
    void Start()
    {   
        health = maxHealth;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(float mod)
    {
        // Updating health
        health += mod; 

        if (health > maxHealth)
        {
            health = maxHealth;
        } 
        else if (health <= 0)
        {
            health = 0;
        }
    }
}
