using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rata : MonoBehaviour {

    public GameObject Humano;
    public Canvas RenderGris;
    public Animator animator;
    public Animator rata;
    public Slider hpBar;
    private int vida;
    int num;

    void Start () {
        //hpBar.value = vida;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.name == "Caleb" && Input.GetKeyDown(KeyCode.Return) && num == 0) {
            //RenderGris.enabled = false;
            animator.SetBool("haSalido", false);
            vida += 10;
            hpBar.value = vida;
            rata.SetBool("isDead", true);
            num++;
            //Destroy(gameObject);
            Destroy(Humano);
        }
    }
}
