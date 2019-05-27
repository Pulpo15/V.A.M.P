using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lamiaScript : MonoBehaviour {

    public Slider hpBar;
    public Rigidbody2D Lamia;
    private Transform target;
    public Collider2D ColliderLamia;
    public Collider2D ColliderLamia2;
    public Collider2D ColliderLamia3;
    public Collider2D ColliderLamia4;
    public Collider2D TriggerLamia;
    //public SpriteRenderer SpriteRenderLamia;
    public ColisionesCaleb Caleb;
    public Reputacion Reputacion;
    public GameObject LamiaGO;
    public Animator LamiaAnimation;

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

    //Var AnimationTime
    private float startAnimationTime = 1;
    public float curAnimationTime;

    //Var Fighting
    private int numCol = 0;
    private int numHit;
    public bool isDead;
    
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeToWait = startTimeToWait;
	}
	
	void Update () {
        Perseguir();
        Timers();
        SetAnimation();
        Lamia.velocity = new Vector3(0, 0, 0);
    }

    void SetAnimation() {
        if (curAnimationTime <= 0) {
            LamiaAnimation.SetBool("Attack", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        ColisionesCaleb player = collider.GetComponent<ColisionesCaleb>();
        if (player)
            numCol++;
        if (collider.gameObject.name == "Caleb") {
            if (numCol == 4) {
                if (Caleb.isDashing) {
                    timeToWait = startTimeToWait;
                    transform.position = Vector2.MoveTowards(transform.position, target.position, 0);
                    Lamia.bodyType = RigidbodyType2D.Static;
                    LamiaAnimation.SetBool("Walking", false);
                    cantMove = true;
                    checkMove = false;
                    numHit++;
                }
                if (numHit == 2) {
                    ColliderLamia.enabled = false;
                    ColliderLamia2.enabled = false;
                    ColliderLamia3.enabled = false;
                    ColliderLamia4.enabled = false;
                    TriggerLamia.enabled = false;
                    //SpriteRenderLamia.enabled = false;
                    isDead = true;
                    cantMove = true;
                    checkMove = false;
                    LamiaAnimation.SetBool("Death", true);
                    //Destroy(LamiaGO);
                }
                else if (attackDeelay <= 0f && Caleb.isDashing == false && cantMove == false) {
                    Lamia.bodyType = RigidbodyType2D.Static;
                    LamiaAnimation.SetBool("Attack", true);
                    curAnimationTime = startAnimationTime;
                    Lamia.transform.position = Vector2.MoveTowards(Lamia.transform.position, target.position, 0);
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
            if (Reputacion.reputation == 10 && numCol == 2)
                checkMove = false;
            //Rata
            if (Reputacion.reputation == 20 && numCol == 1)
                checkMove = false;
            //Humano
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.name == "Caleb") {
            if (!cantMove) {
                print("asd");
                if (Reputacion.reputation == 10 && numCol == 3)
                    checkMove = true;
                    //Rata
                if (Reputacion.reputation == 20 && numCol == 2 || Reputacion.reputation == 20 && numCol == 3)
                    checkMove = true;
                    //Humano
            }
        }
    }

    void Timers() {
        attackDeelay -= Time.deltaTime;
        timeToWait -= Time.deltaTime;
        curAnimationTime -= Time.deltaTime;
    }

    void Perseguir()
    {
        if (checkMove == true)
        {
            Lamia.bodyType = RigidbodyType2D.Dynamic;
            LamiaAnimation.SetBool("Walking", true);
            Lamia.transform.position = Vector2.MoveTowards(Lamia.transform.position, target.position, speed * Time.deltaTime);
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
