using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f; 
    [SerializeField] private float maxHealth = 2000f; 

    public TextMeshProUGUI healthText;

    // Update is called once per frame
    void Update()
    {
        if(HealthScore.playerTotalHealth > 0)
        {
            HealthScore.playerTotalHealth -= Time.deltaTime;
        }

        else if (HealthScore.playerTotalHealth <= 0)
        {
            HealthScore.playerTotalHealth = 0;
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }

        healthText.text = HealthScore.playerTotalHealth.ToString(); 
    }

    public void UpdateHealth(float mod)
    {
        // Updating health
        HealthScore.playerTotalHealth += mod; 

        if (HealthScore.playerTotalHealth > maxHealth)
        {
            HealthScore.playerTotalHealth = maxHealth;
        }

        
    }
}
