using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reputacion : MonoBehaviour {

    public int reputation;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Rata")
            reputation = 10;
        if (collision.gameObject.name == "Humano")
            reputation = 20;
    }
}
