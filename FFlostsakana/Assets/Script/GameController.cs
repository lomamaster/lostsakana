using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public DialogueManager chat;
    public int num;
    public GameObject boss;
    
    public Vector3 respawnPoint;

    public bool isBossDie = false;

    public int bosshealth = 25;

    //public GameObject dialogueEnd;
    //public GameObject showDialogue;

    public void Start()
    {
        //if (boss.activeSelf == true)
        //{
        //    bosshealth = GameObject.FindGameObjectWithTag("Boss").GetComponent<Enemy>().health;
        //}
        //else if(boss.activeSelf == false)
        //{
        //    return;
        //}
    }

    public void Update()
    {
        if (boss == null)
        {
            ////Time.timeScale = 0f;

            //showDialogue.gameObject.SetActive(true);
            //chat.isDialogueEnd = false;
            ////if(chat.isDialogueEnd == false)
            ////{
            //    dialogueEnd.GetComponent<DialogTrigger>().TriggerDialogue();

            //    if (chat.isDialogueEnd == true)
            //    {
                    Nextlevel(num);
            //    }
            ////}
            
        }
    }

    public void GameOver()
    {
        LoadingScreenManager.LoadScene(0);
        Debug.Log("GAME OVER");

    }

    public void Nextlevel(int num)
    {
        
        LoadingScreenManager.LoadScene(num);
    }
}
