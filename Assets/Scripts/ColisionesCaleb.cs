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
    public bool isTouching = false;

    void Start () {
		
	}
	
	void Update () {
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
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
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
            isTouching = false;
            speed = 2.5f;
        }

        //Animations
        if (Input.GetButton("Horizontal"))
        {
            animacion.SetBool("Running", true);
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            animacion.SetBool("Running", false);
        }
        if (Input.GetButton("Vertical"))
        {
            animacion.SetBool("Running", true);
        }
        else if (Input.GetButtonUp("Vertical"))
        {
            animacion.SetBool("Running", false);
        }

        //Movement
        float mH = speed * Input.GetAxis("Horizontal");
        float mV = speed * Input.GetAxis("Vertical");
        Caleb.velocity = new Vector3(mH * speed, Caleb.velocity.y);
        Caleb.velocity = new Vector3(Caleb.velocity.x, mV * speed);
    }
}
