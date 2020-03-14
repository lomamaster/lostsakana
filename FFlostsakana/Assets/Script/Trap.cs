﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.PlayerTakeDamage(999);
        }
    }
}
