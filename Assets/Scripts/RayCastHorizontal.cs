using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastHorizontal : MonoBehaviour {
    Rigidbody2D RCRB;
    public Collider2D Luz;
    public SpriteRenderer SRLuz;

    void Start()
    {
        RCRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Caleb") { }
        else if (collision.gameObject.name == "Cubo")
        {
            //Luz.enabled = false;
            //SRLuz.enabled = false;
            //Luz.transform.localScale -= new Vector3(0.1f, 0, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cubo")
        {
            //Luz.enabled = false;
            //SRLuz.enabled = false;
            if (Luz.transform.localScale.x > 0.1f)
            {
                //Luz.transform.localScale -= new Vector3(0.01f, 0, 0);
                //Luz.transform.position -= new Vector3(0.01f, 0, 0);
                Luz.transform.localScale -= new Vector3(0.01f, 0, 0);
                Luz.transform.position += new Vector3(0, 0.005f, 0);
            }
            else
            {
                Luz.isTrigger = enabled;
                SRLuz.enabled = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Cubo")
        {
            //Luz.enabled = true;
            //SRLuz.enabled = true;
            //Luz.transform.localScale += new Vector3(0.01f, 0, 0);
            //Luz.transform.position += new Vector3(0.01f, 0, 0);
        }
    }

}
