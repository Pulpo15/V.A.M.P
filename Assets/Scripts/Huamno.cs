using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Huamno : MonoBehaviour {

    public GameObject Rata;
    public Canvas RenderGris;
    public Animator animator;
    public Animator human;
    public Slider hpBar;
    private int vida;

    void Start () {
        hpBar.value = vida;
    }
	
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.name == "Caleb" && Input.GetKeyDown(KeyCode.Return)) {
            animator.SetBool("haSalido", false);
            vida += 20;
            hpBar.value = vida;
            human.SetBool("isDead", true);
                      
            Destroy(gameObject);
            Destroy(Rata);
            
        }
    }
}
