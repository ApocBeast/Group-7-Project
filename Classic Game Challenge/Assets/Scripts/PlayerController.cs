using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigi;
    public Animator ani;
    Vector2 playerMovement;
    public int keyCount = 0;


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
    }
}
