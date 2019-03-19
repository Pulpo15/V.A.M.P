using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesCaleb : MonoBehaviour {

    public Rigidbody2D Caleb;
    public Rigidbody2D Cubo;
    public Animator animacion;
    public Collider2D Rata;
    public Collider2D Humano;
    public SpriteRenderer SpriteRata;
    public SpriteRenderer SpriteHumano;
    Vector2 v2;
    public float salto;
    public float speed;
    public float vida;
    public static float vidaParaLamia;
    public int reputacion = 0;
    bool isTouching = false;
    bool isWalking = false;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public float startDashDeelay;
    private float dashDeelay = 0;
    public static bool isDashing = false;
    public static float vidaRecibidaDeLamia;




    void Start() {
        dashTime = startDashTime;
    }

    void Update() {
        Moving();
        Dash();
        vidaParaLamia = vida;
        vidaRecibidaDeLamia = lamiaScript.vidaCaleb;

    }

    void Dash(){
        dashDeelay -= Time.deltaTime;
        if (direction == 0)
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space) && dashDeelay <= 0)
            {
                direction = 1;
                dashDeelay = startDashDeelay;
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space) && dashDeelay <= 0)
            {
                direction = 2;
                dashDeelay = startDashDeelay;
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space) && dashDeelay <= 0)
            {
                direction = 3;
                dashDeelay = startDashDeelay;
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space) && dashDeelay <= 0)
            {
                direction = 4;
                dashDeelay = startDashDeelay;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                Caleb.velocity = Vector2.zero;
                isDashing = false;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    Caleb.velocity = Vector2.left * dashSpeed;
                    isDashing = true;
                }
                else if (direction == 2)
                {
                    Caleb.velocity = Vector2.right * dashSpeed;
                    isDashing = true;
                }
                else if (direction == 3)
                {
                    Caleb.velocity = Vector2.up * dashSpeed;
                    isDashing = true;
                }
                else if (direction == 4)
                {
                    Caleb.velocity = Vector2.down * dashSpeed;
                    isDashing = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cubo")
        {
            
            speed = 1.5f;
            isTouching = true;
        }
        else if (collision.gameObject.name == "Rata")
        {
            if (Input.GetMouseButton(0))
            {
                print("+10 de vida");
                vida = vida + 10;
                reputacion = reputacion - 5;
                Rata.enabled = false;
                SpriteRata.enabled = false;
            }
        }
        else if (collision.gameObject.name == "Humano")
        {
            if (Input.GetMouseButton(0))
            {
                print("+20 de vida");
                vida = vida + 25;
                reputacion = reputacion + 20;
                Humano.enabled = false;
                SpriteHumano.enabled = false;
            }
        }
        else if (collision.gameObject.name == "Lamia")
        {
            print("-15 de vida");
            vida = vidaRecibidaDeLamia;
        }
    }

    void Moving()
    {
        //Movement Direction
        if (Input.GetKeyDown(KeyCode.W) && isTouching == false || Input.GetKeyDown(KeyCode.UpArrow) && isTouching == false)
        {
            Caleb.transform.eulerAngles = new Vector3(0, 0, 0.1f);
        }
        else if (Input.GetKeyUp(KeyCode.S) && isTouching == true || Input.GetKeyUp(KeyCode.DownArrow) && isTouching == true)
        { }
        if (Input.GetKeyDown(KeyCode.S) && isTouching == false || Input.GetKeyDown(KeyCode.DownArrow) && isTouching == false)
        {
            Caleb.transform.eulerAngles = new Vector3(0, 0, 0.2f);
        }
        else if (Input.GetKeyDown(KeyCode.S) && isTouching == true || Input.GetKeyDown(KeyCode.DownArrow) && isTouching == true)
        { }
        if (Input.GetKeyDown(KeyCode.D) && isTouching == false || Input.GetKeyDown(KeyCode.RightArrow) && isTouching == false)
        {
            Caleb.transform.eulerAngles = new Vector3(0, 0, 0);
            v2.x = 1f;
        }
        else if (Input.GetKeyDown(KeyCode.D) && isTouching == true || Input.GetKeyDown(KeyCode.RightArrow) && isTouching == true)
        { }
        if (Input.GetKeyDown(KeyCode.A) && isTouching == false || Input.GetKeyDown(KeyCode.LeftArrow) && isTouching == false)
        {
            Caleb.transform.eulerAngles = new Vector3(0, 180, 0);
            v2.x = -1f;
        }
        else if (Input.GetKeyDown(KeyCode.A) && isTouching == true || Input.GetKeyDown(KeyCode.LeftArrow) && isTouching == true)
        { }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animacion.SetBool("Walking", false);
            isWalking = false;
            isTouching = false;
            speed = 2.5f;
        }

        //Animations
        if (Input.GetButton("Horizontal") && isWalking == false)
        {
            animacion.SetBool("Running", true);
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            animacion.SetBool("Running", false);
        }
        if (Input.GetButton("Vertical") && isWalking == false)
        {
            animacion.SetBool("Running", true);
        }
        else if (Input.GetButtonUp("Vertical"))
        {
            animacion.SetBool("Running", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) || isTouching == true)
        {
            speed = 1.5f;
            animacion.SetBool("Walking", true);
            isWalking = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animacion.SetBool("Walking", false);
            speed = 2.5f;
            isWalking = false;
        }

        //Movement
        float mH = speed * Input.GetAxis("Horizontal");
        float mV = speed * Input.GetAxis("Vertical");
        Caleb.velocity = new Vector3(mH * speed, Caleb.velocity.y);
        Caleb.velocity = new Vector3(Caleb.velocity.x, mV * speed);
    }
}
