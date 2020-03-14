using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCreateDialogue : MonoBehaviour
{
    public GameObject showDialogue;

    public GameObject triggered;

    private DialogTrigger getdatatrigger;

    void Awake()
    {
        //getdatatrigger = GameObject.FindGameObjectWithTag("Trigger").GetComponent<DialogTrigger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            Time.timeScale = 0f;

            showDialogue.gameObject.SetActive(true);
            //getdatatrigger.GetComponent<DialogTrigger>().TriggerDialogue();
            //triggered = getdatatrigger;
            triggered.GetComponent<DialogTrigger>().TriggerDialogue();
            triggered.gameObject.SetActive(false);
        }
    }
}
