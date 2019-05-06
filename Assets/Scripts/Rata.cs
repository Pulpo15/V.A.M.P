using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rata : MonoBehaviour {

    public GameObject Humano;
    public Canvas RenderGris;
    public Animator animator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Caleb" && Input.GetKeyDown(KeyCode.Return))
        {
            //RenderGris.enabled = false;
            animator.SetBool("haSalido", false);
            Destroy(gameObject);
            Destroy(Humano);
        }
    }
}
