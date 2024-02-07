using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigi;
    public Animator ani;
    Vector2 playerMovement;


    public int keyCount = 0;

    public int score; 
    public TextMeshProUGUI scoreText;

    public GameObject projectilePrefab;
    Vector2 lookDirection = new Vector2(1,0);



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player Input
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        // Player Animation
        ani.SetFloat("Horizontal", playerMovement.x);
        ani.SetFloat("Vertical", playerMovement.y);
        ani.SetFloat("Speed", playerMovement.sqrMagnitude);

        if(!Mathf.Approximately(playerMovement.x, 0.0f) || !Mathf.Approximately(playerMovement.y, 0.0f))
        {
            lookDirection.Set(playerMovement.x, playerMovement.y);
            lookDirection.Normalize();
        }

        if(Input.GetMouseButtonDown(0))
        {
            Launch();
        }
    }

    void FixedUpdate()
    {
        // Player Movement
        rigi.MovePosition(rigi.position + playerMovement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Key")
        {
            keyCount++;
        }

        if(other.gameObject.tag == "Chest")
        {
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        score += 1000;
        scoreText.text = score.ToString();
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigi.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
    }
}

