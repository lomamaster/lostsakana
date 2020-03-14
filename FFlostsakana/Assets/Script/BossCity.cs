using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCity : MonoBehaviour
{
    private Transform playerpos;
    public Animator animator;
    public float speed;
    public Vector2 x;
    private Enemy thisBoss;
    private PlayerController player;
    public GameObject Bossjibunn;
    public GameObject beamleft;
    public GameObject beamright;
    public Transform shotspawn;
    private Animator Anim;

    //public GameObject dialogueEnd;
    //public int health;

    private bool facingRight = true;
    public bool isBossDie = false;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();

        playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        isBossDie = GameObject.FindGameObjectWithTag("Boss").GetComponent<Enemy>().thisBossDie;
    }

    void Awake()
    {
        //bosshealth = thisBoss.bosshealth;
    }

    // Update is called once per frame
    void Update()
    {
        //if(thisBoss.thisBossDie == true)
        //{
        //    isBossDie = true;
        //}

        Vector2 target = new Vector2(playerpos.position.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        x = Bossjibunn.transform.position - playerpos.position;

        if(x.x < 0 || x.x > 0)
        {
            Anim.SetBool("bossOneWalk", true);
        }
        else
        {
            Anim.SetBool("bossOneWalk", false);
        }

        if (facingRight == true && x.x < 0 || x.x > 0 && facingRight == false)
        {
            Flip();
            if (facingRight == true)
            {
                Anim.SetTrigger("bossOneATK");

                atkleft();
            }
            else if (facingRight == false)
            {
                Anim.SetTrigger("bossOneATK");

                atkright();
            }
        }
        
        //else if(x.x > 0)
        //{
        //    Flip();
        //}

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {

    //        player.PlayerTakeDamage(10);
    //        //StartCoroutine(player.KnockBack(0.5f, 10, player.transform.position));
    //    }
    //}

    void atkright()
    {
        Instantiate(beamright, shotspawn.position, shotspawn.rotation);
    }
    void atkleft()
    {
        Instantiate(beamleft, shotspawn.position, shotspawn.rotation);
    }

    


}