using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesCaleb : MonoBehaviour {

    public Rigidbody2D Caleb;
    public Rigidbody2D Cubo;
    public Collider2D CuboCollider;
    Vector2 v2;
    public float salto;
    public float speed;
    bool IsTouchingCubo = false;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Moving();
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cubo")
        {
            ColisionCubo(collision);
        }
    }

    void ColisionCubo(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.E) == false && IsTouchingCubo == false)
        { 
            if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0))
            {
                collision.transform.position = new Vector3(Caleb.position.x, Caleb.position.y + 1);
                collision.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
                IsTouchingCubo = true;
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 180))
            {
                collision.transform.position = new Vector3(Caleb.position.x, Caleb.position.y - 1f);
                collision.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
                IsTouchingCubo = true;
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 90))
            {
                collision.transform.position = new Vector3(Caleb.position.x - 1, Caleb.position.y);
                collision.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
                IsTouchingCubo = true;
            }
            else 
            {
                collision.transform.position = new Vector3(Caleb.position.x + 1, Caleb.position.y);
                collision.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
                IsTouchingCubo = true;

            }
        }
        else if (Input.GetKey(KeyCode.E) == true)
        {
            Cubo.velocity = new Vector3(0, 0, 0);
            Caleb.velocity = new Vector3(0, 0, 0);
            IsTouchingCubo = false;
            if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0))
            {
                collision.transform.position = new Vector3(Caleb.position.x, Caleb.position.y + 1.1f);
                collision.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);

            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 180))
            {
                collision.transform.position = new Vector3(Caleb.position.x, Caleb.position.y - 1.1f);
                collision.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 90))
            {
                collision.transform.position = new Vector3(Caleb.position.x - 1.1f, Caleb.position.y);
                collision.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else
            {
                collision.transform.position = new Vector3(Caleb.position.x + 1.1f, Caleb.position.y);
                collision.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
        }
    }

    void PosicionCubo (int direccion)
    {
       
    }

    void Moving()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Caleb.transform.eulerAngles = new Vector3(0, 0, 0);
            v2.x = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Caleb.transform.eulerAngles = new Vector3(0, 0, 180);
            v2.x = 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Caleb.transform.eulerAngles = new Vector3(0, 0, -90);
            v2.x = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Caleb.transform.eulerAngles = new Vector3(0, 0, 90);
            v2.x = -1f;
        }
        float mH = speed * Input.GetAxis("Horizontal");
        float mV = speed * Input.GetAxis("Vertical");
        Caleb.velocity = new Vector3(mH * speed, Caleb.velocity.y, mV * speed);
        Caleb.velocity = new Vector3(Caleb.velocity.x, mV * speed);
    }
}
