using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    
    private float lastShootTime;
    private float fireRate;
    private float fireSpeed = 5;
    
    private void Start()
    {
        fireRate = Random.Range(7, 15);
    }

    void Update()
    {
        Shoot();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void Shoot()
    {
        if (Time.time<lastShootTime+fireRate) return;
        
        var tempBullet = Instantiate(bullet, transform.position,Quaternion.identity);
        var rb = tempBullet.GetComponent<Rigidbody2D>();
        rb.velocity=Vector2.down*fireSpeed;
        lastShootTime = Time.time;
        fireRate = Random.Range(7, 15);
    }
}
