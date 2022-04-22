using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{


    public Dialogue dialogue;
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    private bool playerInRange;


    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            playerInRange = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }


    }


    private void Update()
    {
        // if dialog is playing, the visual que will become inactive, and we won't be able to trigger this again until the dialogue has stopped playing <3
        if (playerInRange)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.I))
            {
                TriggerDialogue();
            }
        }

        else
        {
            visualCue.SetActive(false);
        }
    }


    public void TriggerDialogue()
    {
        // singleton
        DialogueManager.GetInstance().StartDialogue(dialogue);
       // FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }





}
