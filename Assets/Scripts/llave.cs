using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llave : MonoBehaviour {

    public SpriteRenderer Llave;
    public SpriteRenderer puerta;
    public Collider2D colliderPuerta;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Caleb")
        {
            Llave.enabled = false;
            puerta.enabled = false;
            colliderPuerta.enabled = false;

        }
    }
}
