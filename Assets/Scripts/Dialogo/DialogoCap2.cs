using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogoCap2 : MonoBehaviour
{

    //GameObjects
    public Canvas Texto;
    public Canvas CanvasObjetivos;
    public Text VarTexto;
    public Text VarTitulo;
    public Text Objetvios;
    public Rigidbody2D Caleb;
    //Variables
    private bool isOnText = true;
    private readonly float timeToWait = 5.0f;
    private float timeToWaitCur;
    private int Dialog = 0;
    private readonly float timeBetweenScenes = 5;
    private float timeBetweenScenesCur;

    private void Start()
    {
        Dialog = 0;
        CanvasObjetivos.enabled = false;
        Texto.enabled = false;
        timeToWaitCur = timeToWait;
        timeBetweenScenesCur = timeBetweenScenes;
        isOnText = true;
        Caleb.bodyType = RigidbodyType2D.Static;
    }

    private void Update()
    {
        ShowText();
        print(Dialog);
    }

    void ShowText()
    {
        timeToWaitCur -= Time.deltaTime;
        if (isOnText && Dialog == 0 && timeToWaitCur <= 0)
        {
            Caleb.bodyType = RigidbodyType2D.Static;
            VarTexto.text = "*Bleh*";
            Texto.enabled = true;
            Dialog = 1;
        }
        else if (isOnText && Dialog == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            VarTexto.text = "Que sitio más asqueroso";
            
            Dialog = 2;
        }
        else if (isOnText && Dialog == 2 && Input.GetKeyDown(KeyCode.Return))
        {
            Objetvios.text = "Encuentra la manera de llegar al laboratorio";
            CanvasObjetivos.enabled = true;
            Texto.enabled = false;
            Dialog = 3;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
      
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

    }

}