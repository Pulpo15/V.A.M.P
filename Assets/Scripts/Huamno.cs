using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Huamno : MonoBehaviour {

    public GameObject Rata;
    public PasarVariables pasarVariables;
    public Canvas RenderGris;
    public Animator animator;
    public Animator human;
    public Slider hpBar;
    public float vida;
    int num;

    void Start () {
        //hpBar.value = vida;
        pasarVariables = GameObject.FindGameObjectWithTag("Variables").GetComponent<PasarVariables>();
        vida = pasarVariables.Vida;
    }

    private void Update() {
        vida = hpBar.value;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.name == "Caleb" && Input.GetKeyDown(KeyCode.Return) && num == 0) {
            animator.SetBool("haSalido", false);
            vida += 20;
            hpBar.value = vida;
            human.SetBool("isDead", true);
            num++;                      
            Destroy(Rata);
            
        }
    }
}
