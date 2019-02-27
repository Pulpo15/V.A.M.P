using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesCaleb : MonoBehaviour {

    public Rigidbody2D Caleb;
    public Rigidbody2D Cubo;
    public Animator animacion;
    Vector2 v2;
    public float salto;
    public float speed;
    bool isTouching = false;
    bool isWalking = false;

    void Start() {

    }

    void Update() {
        Moving();
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
    }

    void Moving()
    {
        //Movement Direction
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        { }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        { }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        { }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        { }

        if (Input.GetKeyDown(KeyCode.D) && isTouching == false || Input.GetKeyDown(KeyCode.RightArrow) && isTouching == false)
        {
            Caleb.transform.eulerAngles = new Vector3(0, 0, 0);
            v2.x = 1f;
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Caleb.velocity = new Vector3(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D) && isTouching == true || Input.GetKeyDown(KeyCode.RightArrow) && isTouching == true)
        { }
        if (Input.GetKeyDown(KeyCode.A) && isTouching == false || Input.GetKeyDown(KeyCode.LeftArrow) && isTouching == false)
        {
            Caleb.transform.eulerAngles = new Vector3(0, 180, 0);
            v2.x = -1f;
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Caleb.velocity = new Vector3(0, 0, 0);
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
