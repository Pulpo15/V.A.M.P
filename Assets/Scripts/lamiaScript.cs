using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamiaScript : MonoBehaviour {

    public float speed;
    public Rigidbody2D Lamia;
    private Transform target;
    private static bool isDashing;
    public static float vidaCaleb;
    private bool cantMove = false;
    public float startTimeToWait;
    private float timeToWait = 0f;
    public Collider2D ColliderLamia;
    public SpriteRenderer SpriteRenderLamia;
    public float startAttackDeelay;
    private float attackDeelay = 0f;

    
    // Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeToWait = startTimeToWait;
        
	}
	
	// Update is called once per frame
	void Update () {
        //cuando caleb toque algo, lamia persigue
        Perseguir();
        isDashing = ColisionesCaleb.isDashing;
        vidaCaleb = ColisionesCaleb.vidaParaLamia;
        
        attackDeelay -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Caleb")
        {
            if (isDashing == true)
            {
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
            if (Input.GetMouseButton(0) && cantMove == true)
            {
                ColliderLamia.enabled = false;
                SpriteRenderLamia.enabled = false;
            }
            else if (attackDeelay <= 0f)
            {
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
