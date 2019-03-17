using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOut : MonoBehaviour {

    public Collider2D Luz;
    public SpriteRenderer SRLuz;

    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Cubo")
        {
            Luz.enabled = true;
            SRLuz.enabled = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
