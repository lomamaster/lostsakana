using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCastle : MonoBehaviour
{
    private Animator Anim;
    private Enemy thisBoss;
    private PlayerController player;
    private Rigidbody2D rb;

    public GameObject standPoint;
    public GameObject flyPoint;
    public GameObject slash;
    public GameObject lighting;
    public GameObject[] stabPoint;
    public GameObject currentPoint;

    public Transform spawnslash;
    public Transform spawnL;
    public Transform spawnR;
    private Transform playerpos;

    public Vector2 pos;

    public int stabthis;
    
    public float speed;
    public float check;
    public float timeBtwAttack;
    public float startTimeBtwAttack;

    private bool facingRight = true;
    private bool fly = false;

    // Start is called before the first frame update
    void Start()
    {
        playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        pos = this.transform.position - playerpos.position;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        Vector2 target = new Vector2(playerpos.position.x, playerpos.position.y);
        Vector2 standSlash = new Vector2(standPoint.transform.position.x, standPoint.transform.position.y);
        Vector2 flylimit = new Vector2(flyPoint.transform.position.x, flyPoint.transform.position.y);
        Vector2 flying = new Vector2(playerpos.position.x, flyPoint.transform.position.y);

        //if (fly)
        //{
            //anim fly
            check += Time.deltaTime;

        if (check >= 0)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, flying, speed * Time.deltaTime);
            if (this.transform.position.x == playerpos.transform.position.x)
            {
                lightoutL();
                lightoutR();

                stabPoint = GameObject.FindGameObjectsWithTag("stabposition");
                stabthis = Random.Range(0, stabPoint.Length);
                currentPoint = stabPoint[stabthis];
                Vector2 stabhere = new Vector2(currentPoint.transform.position.x, currentPoint.transform.position.y);
                //GetComponent<Rigidbody2D>().AddForce(Vector2.zero, ForceMode2D.Impulse);
                
                if (check >= 7)
                {
                    check = -6;
                    timeBtwAttack = 0;
                }
            }

        }
        else if (check < 0)
        {
            //stand
            fly = false;
            this.transform.position = Vector2.MoveTowards(this.transform.position, standSlash, speed * 1.5f * Time.deltaTime);

            if (this.transform.position == standPoint.transform.position)
            {
                timeBtwAttack += Time.deltaTime;

                if (timeBtwAttack >= 0.3 && timeBtwAttack <= 0.4)
                {
                    SlashOut();
                }
                else if (timeBtwAttack >= 1.3 && timeBtwAttack <= 1.4)
                {
                    SlashOut();
                }
                else if (timeBtwAttack >= 2.3 && timeBtwAttack <= 2.4)
                {
                    SlashOut();
                }
                else if (timeBtwAttack >= 3)
                {
                    this.transform.position = Vector2.MoveTowards(this.transform.position, flylimit, speed * Time.deltaTime);
                    if (this.transform.position == flyPoint.transform.position)
                    {
                        timeBtwAttack = startTimeBtwAttack;
                        fly = true;
                    }
                }
            }
        }
        //}

        if (facingRight == true && pos.x < 0)
        {
            Flip();
        }
        else if (pos.x > 0 && facingRight == false)
        {
            Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    void SlashOut()
    {
        Instantiate(slash, spawnslash.position, spawnslash.rotation);
    }
    void lightoutL()
    {
        Instantiate(lighting, spawnL.position, spawnL.rotation);
    }
    void lightoutR()
    {
        Instantiate(lighting, spawnR.position, spawnR.rotation);
    }
}
