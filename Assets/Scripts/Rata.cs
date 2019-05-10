using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rata : MonoBehaviour {

    public GameObject Humano;
    public Canvas RenderGris;
    public Animator animator;
    public Slider hpBar;
    private int vida = 10;

    // Use this for initialization
    void Start () {
        hpBar.value = vida;
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
            vida += 10;
            hpBar.value = vida;
            Destroy(gameObject);
            Destroy(Humano);
        }
    }
}
