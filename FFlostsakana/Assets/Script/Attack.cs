using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private Animator Anim;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public GameObject praticle;

    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.C))
            {
                Anim.SetTrigger("ATK");
                praticle.gameObject.SetActive(true);
                Collider2D[] enemieToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                FindObjectOfType<AudioManager>().Play("ATK");

                for (int i = 0; i < enemieToDamage.Length; i++)
                {
                    enemieToDamage[i].GetComponent<Enemy>().EnemyTakeDamage(damage);
                    //enemieToDamage[i].GetComponent<BossCity>().EnemyTakeDamage(damage);
                    //enemieToDamage[i].GetComponent<BossForest>().EnemyTakeDamage(damage);
                    //enemieToDamage[i].GetComponent<BossCastle>().EnemyTakeDamage(damage);
                    FindObjectOfType<AudioManager>().Play("dart");
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }   
        else
        {
            timeBtwAttack -= Time.deltaTime;
            praticle.gameObject.SetActive(false);

        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
