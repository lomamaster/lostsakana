using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHP : MonoBehaviour
{
    public PlayerController player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.Healing(10);
            Destroy(gameObject);
        }
    }
}
