using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rata : MonoBehaviour {

    public GameObject Humano;
    public PasarVariables pasarVariables;
    public Canvas RenderGris;
    public Animator animator;
    public Animator rata;
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
            vida += 15;
            hpBar.value = vida;
            rata.SetBool("isDead", true);
            num++;
            Destroy(Humano);
        }
    }
}
