using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    [SerializeField] private float attackDamage = 50f;
    // Enemy will only be able to take every half second
    //[SerializeField] private float attackRate = 0.5f;
    //private float attackAble;

    private Transform target;
    public float moveSpeed = 2f;

    


    private void OnStart()
    {
        //rigi = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    // This function will detect if the enemy collides with the "Player" game object. If it does, damage will be dealt to the player and the enemy will destroy on collision. 
    private void OnCollisionStay2D(Collision2D other)
    {
        /*if (other.gameObject.tag == "Player")
        {
            if (attackRate <= attackAble)
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                attackAble = 0f; 
            }
            else
            {
                attackAble += Time.deltaTime;
            }
        }*/

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
            Destroy(gameObject);
        }
    }
}
