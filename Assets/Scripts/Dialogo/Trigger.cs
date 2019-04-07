using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{

    //public Dialogo dialogo;
    public Canvas Texto;
    public Text VarTexto;
    public Text VarTitulo;
    public bool isOnText = false;
    public bool textTime = false;
    public float timeToWait = 10.0f;
    private float timeToWaitCur;
    public int Dialog = 0;
    public Rigidbody2D Caleb;


    private void Start()
    {
        Texto.enabled = false;
        timeToWaitCur = timeToWait;
        isOnText = true;
    }

    private void Update()
    {
        ShowText();
    }

    void ShowText()
    {
        timeToWaitCur -= Time.deltaTime;
        if (isOnText == true && Dialog == 0 && timeToWaitCur <= 0)
        {
            Caleb.bodyType = RigidbodyType2D.Static;
            print("Asd");
            VarTexto.text = "¿Donde estoy? ¿Cuanto tiempo he dormido?";
            Texto.enabled = true;
            Dialog = 1;

        }
        else if (Input.GetKeyDown(KeyCode.Return) && Dialog == 1 && isOnText == true)
        {
            VarTexto.text = "¿Y mis padres? No me encuentro nada bien.";
            Dialog = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && Dialog == 2 && isOnText == true)
        {
            Texto.enabled = false;
            isOnText = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            textTime = false;
        }
        else if (Dialog == 3 && isOnText == true)
        {
            print("asd");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Diario" && Dialog == 2)
        {
            isOnText = true;
            Dialog = 3;

        }
    }

}