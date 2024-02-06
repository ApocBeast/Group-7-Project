using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f; 
    [SerializeField] private float maxHealth = 2000f; 

    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {   
        health = maxHealth;        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            health -= Time.deltaTime;
        }

        else if (health <= 0)
        {
            health = 0;
        }

        healthText.text = health.ToString(); 
    }

    public void UpdateHealth(float mod)
    {
        // Updating health
        health += mod; 

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        
    }
}
