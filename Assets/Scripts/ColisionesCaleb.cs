using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesCaleb : MonoBehaviour {

    public Rigidbody2D Caleb;
    public Rigidbody2D Cubo;
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
