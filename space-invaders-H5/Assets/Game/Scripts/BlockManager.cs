using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet")||other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
