using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text dialogueText;

    [SerializeField]
    private Animator animator;

    public Queue<string> sentences;


    private void Start()
    {
        sentences = new Queue<string>();
    }

    internal void StartDialog(Dialogue dialogue)
    {
        
        animator.SetBool("isOpen", true);
        sentences.Clear();

        nameText.text = dialogue.name;
        foreach(string sentence in dialogue.sentences) {
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
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char c in sentence.ToCharArray())
        {
            dialogueText.text += c;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
