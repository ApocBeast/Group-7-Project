using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigi;
    Vector2 weaponMovement;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    Vector2 moveDirection;
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        weaponMovement.x = Input.GetAxisRaw("Horizontal"); 
        weaponMovement.y = Input.GetAxisRaw("Vertical"); 

        Fire();

        //moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rigi.MovePosition(rigi.position + weaponMovement * moveSpeed * Time.fixedDeltaTime);
        rigi.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rigi.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rigi.rotation = aimAngle;
    }

    public void Fire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        }
    }
}
