using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossForest : MonoBehaviour
{
    public Transform spawn1;
    public Transform spawn2;
    public GameObject fire;
    public float x;
    private PlayerController player;
    public float speed;
    public float distance;
    public float check;
    private bool movingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            check += Time.deltaTime;
            if (check >= 3)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                check = -3;
                //fire1();
                //fire2();

            }
            else if (check > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                //fire1();
                //fire2();
            }
           
            if (check > 0.2 && check < 0.4)
            {
                fire1();
                fire2();
            }
            else if (check > 2.1 && check < 2.3)
            {
                fire1();
                fire2();
            }
            else if (check > 1.1 && check < 1.3)
            {
                fire1();
                fire2();
            }
            else if (check > 2.6 && check < 2.9)
            {
                fire1();
                fire2();
            }
        }
    }

    void fire1()
    {
        Instantiate(fire,spawn1.position,spawn1.rotation);

    }
    void fire2()
    {
        Instantiate(fire, spawn2.position, spawn2.rotation);
    }
}
