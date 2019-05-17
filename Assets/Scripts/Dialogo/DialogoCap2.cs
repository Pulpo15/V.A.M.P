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
    public Collider2D CientificoMuerto;
    //Variables
    private bool isOnText = true;
    private readonly float timeToWait = 3.0f;
    private float timeToWaitCur;
    private int Dialog = 0;
    private readonly float timeBetweenScenes = 5;
    private float timeBetweenScenesCur;
    //Boleans
    private bool dialogoCientifico;

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

        if (dialogoCientifico && isOnText && Dialog == 3)
        {
            Caleb.bodyType = RigidbodyType2D.Static;
            VarTexto.text = "Las heridas de este científico son muy raras, dos perforaciones circulares. ¿Dónde he escuchado yo eso?";
            CientificoMuerto.enabled = false;
            Texto.enabled = true;
            Dialog = 4;
        }
        else if (dialogoCientifico && isOnText && Input.GetKeyDown(KeyCode.Return) && Dialog == 4)
        {
            print("Text2");
            VarTexto.text = "Parece que tiene una nota";
            Dialog = 5;
        }
        else if (dialogoCientifico && isOnText && Input.GetKeyDown(KeyCode.Return) && Dialog == 5)
        {
            print("Text3");
            VarTexto.text = "Esto se nos ha ido de las manos, ha creado un ser monstruoso que ni siquiera nosotros sabemos de que es capaz. Desde que comenzamos con las pruebas del suero, los sujetos empezaban a perder capacidad visual y la conciencia, tanto que se volvían agresivos. Si no la paramos la seguridad civil se verá en peligro.";
            Dialog = 6;
        }
        else if(dialogoCientifico && isOnText && Input.GetKeyDown(KeyCode.Return) && Dialog == 6)
        {
            print("Text3");
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Texto.enabled = false;
            Dialog = 7;
            dialogoCientifico = false;
            isOnText = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.name == "CientificoMuerto")
        {
            isOnText = true;
            dialogoCientifico = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

}