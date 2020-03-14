using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int bosshealth = 25;

    private PlayerController player;

    public GameObject thisIsBoss;
    public bool thisBossDie = false;
    //public float speed;
    //public float distance;
    //public float check;
    //private bool movingRight =false;

    //public Transform groundDetection;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //bosshealth = this.health;
        //bosshealth = thisIsBoss.GetComponent<Enemy>.health;

        if (health <= 0)
        {
            Enemydie();
        }


        //RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        //if(groundInfo.collider == false)
        //{
        //    if(movingRight == true)
        //    {
        //        transform.eulerAngles = new Vector3(0, -180,0);
        //        movingRight = false;
        //    }
        //    else
        //    {
        //        transform.eulerAngles = new Vector3(0, 0,0);
        //        movingRight = true;
        //    }
        //}

        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        //check += Time.deltaTime;
        //if (check >= 2)
        //{
        //    transform.eulerAngles = new Vector3(0, -180, 0);
        //    check = -2;
            
        //}
        //else if (check>0)
        //{
        //    transform.eulerAngles = new Vector3(0, 0, 0);
        //}
       
        
    }

    public void EnemyTakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("The Enemy damage taken !");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (thisIsBoss == null)
        {
            if (collision.CompareTag("Player"))
            {
                player.PlayerTakeDamage(3);
                StartCoroutine(player.KnockBack(0.5f, 10, player.transform.position));

            }
        }
        else if (thisIsBoss != null)
        {
            if (collision.CompareTag("Player"))
            {
                player.PlayerTakeDamage(5);
                StartCoroutine(player.KnockBack(0.5f, 10, player.transform.position));

            }
        }

    }

    public void Enemydie()
    {
        if (thisIsBoss != null)
        {
            thisBossDie = true;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
