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

    void Start () {
		
	}
	
	void Update () {
        Moving();
	}

    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    void Moving()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Caleb.transform.eulerAngles = new Vector3(0, 0, 0);
            v2.x = 1f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Caleb.transform.eulerAngles = new Vector3(0, 0, 0);
            v2.x = 1f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Caleb.transform.eulerAngles = new Vector3(0, 0, 0);
            v2.x = 1f;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Caleb.transform.eulerAngles = new Vector3(0, 180, 0);
            v2.x = -1f;
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            animacion.SetBool("Running", true);
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            animacion.SetBool("Running", false);
        }
        if (Input.GetButtonDown("Vertical"))
        {
            animacion.SetBool("Running", true);
        }
        else if (Input.GetButtonUp("Vertical"))
        {
            animacion.SetBool("Running", false);
        }
        float mH = speed * Input.GetAxis("Horizontal");
        float mV = speed * Input.GetAxis("Vertical");
        Caleb.velocity = new Vector3(mH * speed, Caleb.velocity.y, mV * speed);
        Caleb.velocity = new Vector3(Caleb.velocity.x, mV * speed);
    }
}
