using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashMove : MonoBehaviour
{
    private PlayerController player;

    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.PlayerTakeDamage(5);

            Destroy(gameObject);
        }
        if (collision.CompareTag("fallDetector"))
        {
            Destroy(gameObject);
        }

    }
}
