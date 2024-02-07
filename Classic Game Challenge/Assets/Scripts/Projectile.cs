using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigi;
    
    void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    
    public void ThrowSword(Vector2 direction, float force)
    {
        rigi.AddForce(direction * (force * 2));
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}