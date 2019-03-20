using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamiaScript : MonoBehaviour {

    public float speed;
    public Rigidbody2D Lamia;
    private Transform target;
    private static bool isDashing;
    private static float vidaCaleb = 20f;
    public static float vidaParaCaleb;
    private bool cantMove = false;
    public float startTimeToWait;
    private float timeToWait = 0f;
    public Collider2D ColliderLamia;
    public SpriteRenderer SpriteRenderLamia;
    public float startAttackDeelay;
    private float attackDeelay = 0f;
    private static int repu;
    private int numCol = 0;
    
    // Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeToWait = startTimeToWait;
        
	}
	
	// Update is called once per frame
	void Update () {
        //cuando caleb toque algo, lamia persigue
        isDashing = ColisionesCaleb.isDashing;
        repu = ColisionesCaleb.repuParaLamia;
        attackDeelay -= Time.deltaTime;
        vidaParaCaleb = vidaCaleb;
        print("Repu en lamia" + repu);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        ColisionesCaleb player = collider.GetComponent<ColisionesCaleb>();
        if (player)
            numCol++;
        print(numCol);

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        ColisionesCaleb player = collider.GetComponent<ColisionesCaleb>();
        if (player)
            numCol--;
        print(numCol);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Caleb" && repu == 10 && numCol == 2 && cantMove == false|| collider.gameObject.name == "Caleb" && repu == 20 && numCol == 2 && cantMove == false)
        {
            Perseguir();
            print("Rata");
        }
        if (collider.gameObject.name == "Caleb" && repu == 20 && numCol == 1 && cantMove == false)
        {
            Perseguir();
            print("Humano");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Caleb")
        {
            if (isDashing == true)
            {
                print("CanDash");
                transform.position = Vector2.MoveTowards(transform.position, target.position, 0);
                Lamia.bodyType = RigidbodyType2D.Static;
                cantMove = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Caleb")
        {
            vidaCaleb = ColisionesCaleb.vidaParaLamia;
            if (Input.GetMouseButton(0) && cantMove == true)
            {
                ColliderLamia.enabled = false;
                SpriteRenderLamia.enabled = false;
            }
            else if (attackDeelay <= 0f && isDashing == false && cantMove == false)
            {
                Lamia.bodyType = RigidbodyType2D.Static;
                transform.position = Vector2.MoveTowards(transform.position, target.position, 0);
                print("Ataque");
                vidaCaleb = vidaCaleb - 15f;
                attackDeelay = startAttackDeelay;
            }
        }
    }
    void Perseguir ()
    {
        timeToWait -= Time.deltaTime;
        if (cantMove == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (timeToWait <= 0)
        {
            cantMove = false;
            timeToWait = startTimeToWait;
        }
    }
}
