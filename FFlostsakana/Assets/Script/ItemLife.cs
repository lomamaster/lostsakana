using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLife : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.LifeRecover(1);
            Destroy(gameObject);
        }
    }
}
