using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lamiaScript : MonoBehaviour {

    public Slider hpBar;
    public Rigidbody2D Lamia;
    private Transform target;
    public Collider2D ColliderLamia;
    public SpriteRenderer SpriteRenderLamia;
    public ColisionesCaleb Caleb;
    public Reputacion Reputacion;

    //Var Movement
    public float speed;
    private bool cantMove;
    private bool checkMove;
    //Var Time
    public float startTimeToWait;
    private float timeToWait = 0f;
    //Var AttackTime
    public float startAttackDeelay;
    private float attackDeelay = 0f;
    //Var Fighting
    private int numCol = 0;
    private int numHit;
    
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeToWait = startTimeToWait;
	}
	
	void Update () {
        Perseguir();
        Timers();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        ColisionesCaleb player = collider.GetComponent<ColisionesCaleb>();
        if (player)
            numCol++;
        if (collider.gameObject.name == "Caleb") {
            if (numCol == 3) {
                if (Caleb.isDashing) {
                    timeToWait = startTimeToWait;
                    transform.position = Vector2.MoveTowards(transform.position, target.position, 0);
                    Lamia.bodyType = RigidbodyType2D.Static;
                    cantMove = true;
                    checkMove = false;
                    numHit++;
                }
                if (numHit == 5) {
                    ColliderLamia.enabled = false;
                    SpriteRenderLamia.enabled = false;
                }
                else if (attackDeelay <= 0f && Caleb.isDashing == false && cantMove == false) {
                    Lamia.bodyType = RigidbodyType2D.Static;
                    transform.position = Vector2.MoveTowards(transform.position, target.position, 0);
                    hpBar.value -= 15f;
                    attackDeelay = startAttackDeelay;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        ColisionesCaleb player = collider.GetComponent<ColisionesCaleb>();
        if (player)
            numCol--;
        if (!cantMove) {
            if (Reputacion.reputation == 10 && numCol == 1)
                checkMove = false;
            //Rata
            if (Reputacion.reputation == 20 && numCol == 0)
                checkMove = false;
            //Humano
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.name == "Caleb") {
            if (!cantMove) {
                print("asd");
                if (Reputacion.reputation == 10 && numCol == 2)
                    checkMove = true;
                    //Rata
                if (Reputacion.reputation == 20 && numCol == 1 || Reputacion.reputation == 20 && numCol == 2)
                    checkMove = true;
                    //Humano
            }
        }
    }

    void Timers() {
        attackDeelay -= Time.deltaTime;
        timeToWait -= Time.deltaTime;
    }

    void Perseguir()
    {
        if (checkMove == true)
        {
            Lamia.bodyType = RigidbodyType2D.Dynamic;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (timeToWait <= 0)
        {
            cantMove = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Caleb") {

        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.name == "Caleb") {
          
        }
    }


}
