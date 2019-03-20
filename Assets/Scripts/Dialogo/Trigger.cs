using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public Dialogo dialogo;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Caleb")
        {
            FindObjectOfType<MainDialogo>().StartDialogo(dialogo);
        }
    }

}