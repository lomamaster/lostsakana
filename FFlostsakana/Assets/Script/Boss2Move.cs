using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Move : MonoBehaviour
{
    public float speed;
    public float distance;
    public float check;
    private bool movingRight = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        check += Time.deltaTime;
        if (check >= 4)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            check = -4;

        }
        else if (check > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
