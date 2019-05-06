using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ColisionesCaleb : MonoBehaviour {

    public Rigidbody2D Caleb;
    public Rigidbody2D Cubo;
    public Animator animacion;
    public Collider2D Rata;
    public Collider2D Humano;
    public Collider2D Puerta1;
    public Collider2D Puerta2;
    public Collider2D Key;
    public SpriteRenderer SpriteKey;
    public SpriteRenderer SpritePuerta2;
    public SpriteRenderer SpritePuerta1;
    public SpriteRenderer SpriteRata;
    public SpriteRenderer SpriteHumano;
    Vector2 v2;
    public Animator animator;
    
    public float salto;
    public float speed;
    public float vida;
    public static float vidaParaLamia;
    private int reputacion = 0;
    public static int repuParaLamia = 0;
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
    public Slider hpBar;
    public bool haveKey = false;

    private float timeToWait = 10.0f;
    private float timeToWaitCur;
    private int numEnter;

    void Start() {
        dashTime = startDashTime;
        timeToWaitCur = timeToWait;
        isWalking = true;
    }

    void Update() {
        Moving();
        Dash();
        Vida();
        ExitToMenu();
        vidaRecibidaDeLamia = lamiaScript.vidaParaCaleb;
        vidaParaLamia = vida;
        repuParaLamia = reputacion;
        hpBar.value = vida;
        print(vida);
        CanWalk();
      }

    void CanWalk()
    {
        timeToWaitCur -= Time.deltaTime;
        if (timeToWaitCur <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                numEnter++;
            }
            if (numEnter == 2)
            {
                isWalking = false;
            }
        }
    }

    void Vida()
    {
        if (vida >= 100)
        {
            vida = 100f;
        }
        else if (vida <= 0)
        {
            print("HasMuerto");
            Destroy(gameObject);
        }
    }

    void Dash(){
        dashDeelay -= Time.deltaTime;
        if (direction == 0)
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space) && dashDeelay <= 0 || Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Space) && dashDeelay <= 0)
            {
                direction = 1;
                dashDeelay = startDashDeelay;
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space) && dashDeelay <= 0 || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.Space) && dashDeelay <= 0)
            {
                direction = 2;
                dashDeelay = startDashDeelay;
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space) && dashDeelay <= 0 || Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.Space) && dashDeelay <= 0)
            {
                direction = 3;
                dashDeelay = startDashDeelay;
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space) && dashDeelay <= 0 || Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.Space) && dashDeelay <= 0)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Llave")
        {
            haveKey = true;
            Key.enabled = false;
            SpriteKey.enabled = false;
        }
        if (collision.gameObject.name == "Diario")
        {
            Puerta1.enabled = false;
            SpritePuerta1.enabled = false;
        }
        if (collision.gameObject.name == "Acceder2Piso")
        {
            gameObject.transform.position = new Vector3(26, 109);
        }
        if (collision.gameObject.name == "Volver1Piso")
        {
            gameObject.transform.position = new Vector3(-13, 101);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cubo")
        {
            speed = 1.5f;
            isTouching = true;
        }

        if (collision.gameObject.name == "Puerta")
        {
            if (haveKey)
            {
                Puerta2.enabled = false;
                SpritePuerta2.enabled = false;
            }
        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Rata")
        {
            if (Input.GetMouseButton(0))
            {
                print("+10 de vida");
                vida = vida + 10;
                reputacion = 10;
                Rata.enabled = false;
                SpriteRata.enabled = false;
                Humano.enabled = false;
                SpriteHumano.enabled = false;                
            }
        }
        else if (collision.gameObject.name == "Humano")
        {
            if (Input.GetMouseButton(0))
            {
                print("+25 de vida");
                vida = vida + 25;
                reputacion = 20;
                Humano.enabled = false;
                SpriteHumano.enabled = false;
                Rata.enabled = false;
                SpriteRata.enabled = false;
            }
        }
        else if (collision.gameObject.name == "Lamia")
        {
            vida = vidaRecibidaDeLamia;
        }
    }

    void Moving()
    {
        //Movement Direction
        if (Input.GetKeyDown(KeyCode.W) && isTouching == false && !isWalking || Input.GetKeyDown(KeyCode.UpArrow) && isTouching == false && !isWalking)
        {
            Caleb.transform.eulerAngles = new Vector3(0, 0, 0.1f);
        }
        else if (Input.GetKeyUp(KeyCode.S) && isTouching == true && isWalking || Input.GetKeyUp(KeyCode.DownArrow) && isTouching == true && isWalking) { }
        if (Input.GetKeyDown(KeyCode.S) && isTouching == false && !isWalking || Input.GetKeyDown(KeyCode.DownArrow) && isTouching == false && !isWalking)
        {
            Caleb.transform.eulerAngles = new Vector3(0, 0, 0.2f);
        }
        else if (Input.GetKeyDown(KeyCode.S) && isTouching == true && isWalking || Input.GetKeyDown(KeyCode.DownArrow) && isTouching == true && isWalking) { }
        if (Input.GetKeyDown(KeyCode.D) && isTouching == false && !isWalking || Input.GetKeyDown(KeyCode.RightArrow) && isTouching == false && !isWalking)
        {
            Caleb.transform.eulerAngles = new Vector3(0, 0, 0);
            v2.x = 1f;
        }
        else if (Input.GetKeyDown(KeyCode.D) && isTouching == true && isWalking || Input.GetKeyDown(KeyCode.RightArrow) && isTouching == true && isWalking) { }
        if (Input.GetKeyDown(KeyCode.A) && isTouching == false && !isWalking || Input.GetKeyDown(KeyCode.LeftArrow) && isTouching == false && !isWalking)
        {
            Caleb.transform.eulerAngles = new Vector3(0, 180, 0);
            v2.x = -1f;
        }
        else if (Input.GetKeyDown(KeyCode.A) && isTouching == true && isWalking || Input.GetKeyDown(KeyCode.LeftArrow) && isTouching == true && isWalking) { }

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

    void ExitToMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0); 
        }
    }
}
