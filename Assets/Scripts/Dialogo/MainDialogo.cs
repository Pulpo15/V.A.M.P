using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDialogo : MonoBehaviour {

    public Text nameText;
    public Text dialogoText;

    private Queue<string> sentences;

    // Use this for initialization
    void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogo(Dialogo dialogo)
    {
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
        if (Input.GetKeyDown(KeyCode.Space))
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
        Debug.Log("Fin de texto");
    }

  
    
}