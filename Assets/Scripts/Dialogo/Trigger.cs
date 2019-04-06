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


    private void Start()
    {
        Texto.enabled = false;
    }

    private void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Diario")
        {
            //FindObjectOfType<MainDialogo>().StartDialogo(dialogo);
            VarTexto.text = "asd";
            Texto.enabled = true;
        }
    }

}