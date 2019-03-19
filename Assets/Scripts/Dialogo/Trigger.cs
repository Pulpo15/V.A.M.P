using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public Dialogo dialogo;


    public void OnTriggerStay2D(Collider2D other)
    {
        FindObjectOfType<MainDialogo>().StartDialogo(dialogo);
    }

}