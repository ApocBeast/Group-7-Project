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

    public AudioSource audioplayer;

    public int keyCount = 0;

    public TextMeshProUGUI scoreText;

    public GameObject projectilePrefab;
    Vector2 lookDirection = new Vector2(1,0);


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
            ThrowSword();
        }

        scoreText.text = HealthScore.playerTotalScore.ToString();
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
        HealthScore.playerTotalScore += 1000;
    }

    void ThrowSword()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigi.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile sword = projectileObject.GetComponent<Projectile>();
        sword.ThrowSword(lookDirection, 300);
    }

    //Sound
    public void OncollisionEnter(Collision2D collision){

        if(collision.gameObject.tag == "Key"){
            audioplayer.Play();
        }
    }

}

