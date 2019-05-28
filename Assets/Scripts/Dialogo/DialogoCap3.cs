using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DialogoCap3 : MonoBehaviour {

    public Canvas Texto;
    public Canvas CanvasObjetivos;

    public Text VarTexto;
    public Text VarTitulo;
    public Text Objetvios;

    public Rigidbody2D Caleb;

    public Animator continuara;

    //Var Time
    private readonly float timeToWait = 3.0f;
    private float timeToWaitCur;

    //Var Dialog
    private int Dialog = 0;

    //Boleans
    public bool isOnText;

    void Start() {
        Dialog = 0;
        CanvasObjetivos.enabled = false;
        Texto.enabled = false;
        timeToWaitCur = timeToWait;
        isOnText = true;
        Caleb.bodyType = RigidbodyType2D.Static;
    }

    void ShowText() {
        timeToWaitCur -= Time.deltaTime;
        if (isOnText && Dialog == 0 && timeToWaitCur <= 0)
        {
            Caleb.bodyType = RigidbodyType2D.Static;
            VarTitulo.text = "Desconocido";
            VarTexto.text = "¡Ya has llegado! Bienvenido a tu casa, por favor no te sientas abrumado por los otros. Se puede notar que se han deteriorado pero siguen siendo los de siempre.";
            Texto.enabled = true;
            Dialog = 1;
        }
        else if (isOnText && Dialog == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            VarTitulo.text = "Desconocido";
            VarTexto.text = "Tan atentos que pueden tanto oler como escucharte. Que pena que no te puedan ver. Ya les gustaría ser como tu.";
            Dialog = 2;
        }
        else if (isOnText && Dialog == 2 && Input.GetKeyDown(KeyCode.Return))
        {
            VarTitulo.text = "Caleb";
            VarTexto.text = "¡¿Quien eres y qué quieres de mi?!";
            Dialog = 3;
        }
        else if (isOnText && Dialog == 3 && Input.GetKeyDown(KeyCode.Return))
        {
            VarTitulo.text = "Desconocido";
            VarTexto.text = "Todo a su debido tiempo. Relájate y verás que las cosas no son tan malas como lo parecen.";
            Dialog = 4;
        }
        else if (isOnText && Dialog == 4 && Input.GetKeyDown(KeyCode.Return))
        {
            VarTitulo.text = "Caleb";
            VarTexto.text = "Pues a mi me parece que son aún peor, y más si me has transformado en algo tan monstruoso.";
            Dialog = 5;
        }
        else if (isOnText && Dialog == 5 && Input.GetKeyDown(KeyCode.Return)) { 
            VarTitulo.text = "Desconocido";
            VarTexto.text = "Ya somos dos. Sabes... me gustaria verte, quiero ver como has mejorado en tan poco tiempo y poderte mejorar aún más. Encontrémonos en la sala de experimentos.";
            Dialog = 6;
        }
        else if (isOnText && Dialog == 6 && Input.GetKeyDown(KeyCode.Return))
        {
            VarTitulo.text = "Desconocido";
            VarTexto.text = "Lo recordarás, es donde trabajaba tu padre.";
            Dialog = 7;
        }
        else if (isOnText && Dialog == 7 && Input.GetKeyDown(KeyCode.Return)) {
            VarTitulo.text = "Caleb";
            VarTexto.text = "*Grrr*";
            Dialog = 8;
        }
        else if (isOnText && Dialog == 8 && Input.GetKeyDown(KeyCode.Return)) {
            VarTitulo.text = "Caleb";
            VarTexto.text = "Voy a por ti";
            Dialog = 9;
        }
        if(Dialog == 9)
        {
            continuara.SetBool("dialogFinish", true);
        }

    }


    void Update()
    {
        ShowText();
    }
}
