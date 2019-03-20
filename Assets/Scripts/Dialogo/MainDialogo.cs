using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDialogo : MonoBehaviour {

    public Text nameText;
    public Text dialogoText;
    public Animator animator;

    private Queue<string> sentences;

    // Use this for initialization
    void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogo(Dialogo dialogo)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogo.name;

        sentences.Clear();

        foreach (string sentence in dialogo.sentences)
        {
            sentences.Enqueue(sentence);
        }

        ShowNextSentence();
    }

    public void ShowNextSentence()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (sentences.Count == 0)
            {
                EndDialogo();
                return;
            }
            string sentence = sentences.Dequeue();
            dialogoText.text = sentence;
        }
        
        
    }

    void EndDialogo()
    {
        animator.SetBool("isOpen", false);
    }

  
    
}