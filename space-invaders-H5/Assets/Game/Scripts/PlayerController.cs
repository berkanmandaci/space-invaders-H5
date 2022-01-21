using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform maxLeftMovePos;
    [SerializeField] private Transform maxRightMovePos;
    [SerializeField] private Transform player;
    [SerializeField] private Transform firePos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fireSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bullet;

    private float lastShootTime;

    void Update()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position= Vector3.MoveTowards(player.transform.position,maxLeftMovePos.position,moveSpeed*Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position= Vector3.MoveTowards(player.transform.position,maxRightMovePos.position,moveSpeed*Time.deltaTime);
        }
    }

    private void Shoot()
    {
        if (Time.time<lastShootTime+fireRate) return;
        
        if (Input.GetKey(KeyCode.Space))
        {
            var tempBullet = Instantiate(bullet, firePos.position,Quaternion.identity);
            var rb = tempBullet.GetComponent<Rigidbody2D>();
            rb.velocity=Vector2.up*fireSpeed;
            lastShootTime = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            //TODO game over
        }
    }
}
