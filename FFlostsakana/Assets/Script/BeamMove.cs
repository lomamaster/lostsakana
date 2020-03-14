using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamMove : MonoBehaviour
   
{
    public float velX = 5;
    float velY;
    public Rigidbody2D rb;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX,velY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            player.PlayerTakeDamage(10);
        }
            Destroy(gameObject);

    }
}
