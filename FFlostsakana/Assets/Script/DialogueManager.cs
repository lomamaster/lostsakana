using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public bool isDialogueEnd = false;

    public Text nameText;
    public Text dialogueText;
    public Image protrail;

    public GameObject showDialogue;

    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<Sprite> images;

    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        images = new Queue<Sprite>();

    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with" + dialogue.names);
        isDialogueEnd = false;
        names.Clear();
        sentences.Clear();
        images.Clear();

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (Sprite image in dialogue.images)
        {
            images.Enqueue(image);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        string name = names.Dequeue();
        
        Sprite image = images.Dequeue();

        string sentence = sentences.Dequeue();

        if (sentences.Count <= 0)
        {
            Time.timeScale = 1f;
            EndDialogue();
            return;
        }

        protrail.overrideSprite = image;
        nameText.text = name;
        //dialogueText.text = sentence;
        StopAllCoroutines();
        //StartCoroutine(typeName(name));
        StartCoroutine(typeSentence(sentence));

        Debug.Log(sentence);
    }

    IEnumerator typeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }
    //IEnumerator typeName (string name)
    //{
    //    nameText.text = "";

    //    foreach (char textname in name.ToCharArray())
    //    {
    //        nameText.text += textname;
    //        yield return null;
    //    }
    //}

    void EndDialogue()
    {
        showDialogue.gameObject.SetActive(false);
        isDialogueEnd = true;
        Debug.Log("End of conversation.");
    }
}
