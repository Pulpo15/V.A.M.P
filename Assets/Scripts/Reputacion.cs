using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reputacion : MonoBehaviour {

    public PasarVariables PasarVariable;
    public int reputation;

    private void Start() {
        PasarVariable = GameObject.FindGameObjectWithTag("Variables").GetComponent<PasarVariables>();
        reputation = PasarVariable.Repu;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Rata" && Input.GetKeyDown(KeyCode.Return))
            reputation = 10;
        if (collision.gameObject.name == "Humano" && Input.GetKeyDown(KeyCode.Return))
            reputation = 20;
    }
}
