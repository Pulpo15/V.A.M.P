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
    public float timeToWait = 10.0f;
    private float timeToWaitCur;
    public int Dialog = 0;


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
        if (isOnText == true && Dialog == 0 && timeToWaitCur == 0)
        {
            VarTexto.text = "¿Donde estoy? ¿Cuanto tiempo he dormido?";
            Texto.enabled = true;
            Dialog = 1;
            if (Input.GetKey(KeyCode.Return) && Dialog == 1 && isOnText == true)
            {
                VarTexto.text = "¿Y mis padres? Me encuentro fatal.";
                Dialog = 2;
            }
        }
        else if (Input.GetKey(KeyCode.Return) && Dialog == 2 && isOnText == true)
        {
            Texto.enabled = false;
            isOnText = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Diario")
        {
            //FindObjectOfType<MainDialogo>().StartDialogo(dialogo);
            isOnText = true;

        }
    }

}