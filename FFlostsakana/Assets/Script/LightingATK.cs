using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingATK : MonoBehaviour
{
    private PlayerController player;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.PlayerTakeDamage(1);

            Destroy(gameObject);
        }
        if (collision.CompareTag("fallDetector"))
        {
            Destroy(gameObject);
        }

    }
}
