using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{

    //singleton class
    private static DialogueManager instance;

    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;


    public Animator animator;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one dialogue Manager!");
        }


        instance = this;
    }

    // singleton
    public static DialogueManager GetInstance()
    {
        return instance;
    }

    void Start()
    {
        sentences = new Queue<string>();

    }


    public void StartDialogue(Dialogue d)
    {
        animator.SetBool("isOpen", true);

        nameText.text = d.relation;
        sentences.Clear();

        foreach (string sentence in d.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string s = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Typesentence(s));

    }



    IEnumerator Typesentence(string s)
    {
        dialogueText.text = "";
        foreach (char letter in s.ToCharArray())
        {
            dialogueText.text += letter;

            yield return new WaitForSeconds(0.05f)
;        }
    }

    void EndDialogue()
    {
        Debug.Log("End of Conversation!");
        animator.SetBool("isOpen", false);
    }



}