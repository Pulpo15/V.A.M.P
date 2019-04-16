using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{

    //public Dialogo dialogo;
    public Canvas Texto;
    public Canvas CanvasObjetivos;
    public Canvas Diario1;
    public Text VarTexto;
    public Text VarTitulo;
    public Text Objetvios;
    public bool isOnText = true;
    public bool textTime = false;
    public float timeToWait = 5.0f;
    private float timeToWaitCur;
    public int Dialog = 0;
    public Rigidbody2D Caleb;
    public SpriteRenderer SpriteDiario;
    public bool dialogoLlave = false;
    public int dialogoCaja = 1;
    public bool dialogoPuerta = false;
    public BoxCollider2D BoxPuerta1;


    private void Start()
    {
        CanvasObjetivos.enabled = false;
        Texto.enabled = false;
        Diario1.enabled = false;
        timeToWaitCur = timeToWait;
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
        //Texto AfterWakeUp
        if (isOnText == true && Dialog == 0 && timeToWaitCur <= 0)
        {
            Caleb.bodyType = RigidbodyType2D.Static;
            VarTexto.text = "¿Donde estoy? ¿Cuanto tiempo he dormido?";
            Texto.enabled = true;
            Dialog = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && Dialog == 1 && isOnText)
        {
            VarTexto.text = "¿Y mis padres? No me encuentro nada bien.";
            Dialog = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && Dialog == 2 && isOnText)
        {
            Texto.enabled = false;
            isOnText = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            textTime = false;
            Objetvios.text = "Explora el Almacén";
            CanvasObjetivos.enabled = true;
            Dialog = 3;
        }
        //Texto Diario
        if (Dialog == 3 && isOnText)
        {
            Caleb.bodyType = RigidbodyType2D.Static;
            Diario1.enabled = true;
            SpriteDiario.enabled = false;
            Dialog = 4;
        }
        else if (Dialog == 4 && Input.GetKeyDown(KeyCode.Return) && isOnText)
        {
            Diario1.enabled = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Dialog = 5;
            isOnText = false;
        }
        //Texto Salir Primera Habitación
        if (Dialog == 5 && isOnText)
        {
            Caleb.bodyType = RigidbodyType2D.Static;
            VarTexto.text = "Debería salir de este almacén y pedir ayuda.";
            Texto.enabled = true;
            Dialog = 6;
        }
        else if (Dialog == 6 && Input.GetKeyDown(KeyCode.Return) && isOnText)
        {
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Texto.enabled = false;
            Dialog = 7;
            Objetvios.text = "Encuentra una Salida";
        }
        //Dialogo Llave
        if (dialogoLlave)
        {
            VarTexto.text = "Seguro que esta llave sirve para algo.";
            Texto.enabled = true;
            Caleb.bodyType = RigidbodyType2D.Static;
        }
        if (dialogoLlave && Input.GetKeyDown(KeyCode.Return))
        {
            Texto.enabled = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            dialogoLlave = false;
        }
        //Dialogo Caja
        if (dialogoCaja == 2 && isOnText)
        {
            VarTexto.text = "Parece que puedo mover esa caja\n(Pulsa E para soltar la caja)";
            Texto.enabled = true;
            Caleb.bodyType = RigidbodyType2D.Static;
        }
        if (dialogoCaja == 2 && isOnText && Input.GetKeyDown(KeyCode.Return))
        {
            Texto.enabled = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            isOnText = false;
            dialogoCaja++;
        }
        //Dialogo Puerta
        if (dialogoPuerta && Input.GetKeyDown(KeyCode.Return))
        {
            Texto.enabled = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            dialogoPuerta = false;
            
            print("asd");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Diario" && Dialog == 3)
        {
            isOnText = true;
        }
        if (col.gameObject.name == "SalirHabitación")
        {
            isOnText = true;
        }
        if (col.gameObject.name == "Llave")
        {
            dialogoLlave = true;
        }
        //if (col.gameObject.name == "Puerta")
        //{
        //    BoxPuerta1.size = new Vector3(1, 2.217735f, 1);
        //}
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Cubo")
        {
            dialogoCaja++;
            isOnText = true;
        }
        if (col.gameObject.name == "Puerta")
        {
            //isOnText = true;
            //BoxPuerta1.size = new Vector3(0.4205475f, 2.217735f, 1);
            dialogoPuerta = true;
            VarTexto.text = "Parece cerrada, voy a necesitar algo para abrirla";
            Texto.enabled = true;
            Caleb.bodyType = RigidbodyType2D.Static;



        }
    }

}