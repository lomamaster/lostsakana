using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeelee : MonoBehaviour
{
    public float speed;
    public float distance;
    public float check;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        check += Time.deltaTime;
        if (check >= 2)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            check = -2;

        }
        else if (check > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
