using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

    //public Transform RCBeg, RCEnd;
    Rigidbody2D RCRB;
    public Collider2D Luz;
    //RaycastHit2D hit;
    public SpriteRenderer SRLuz;



    // Use this for initialization
    void Start () {
        RCRB = GetComponent<Rigidbody2D>();
	}
    //void Raycasting()
    //{
    //    Debug.DrawLine(RCBeg.position, RCEnd.position, Color.black);
    //    if (Physics.Raycast())
    //    {
    //        console.log("Ray");
    //    }
    //}
    //Update is called once per frame

    void Update () {

        //Raycasting();

	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Caleb")
        { }
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
                Luz.transform.localScale -= new Vector3(0.01f, 0, 0);
                Luz.transform.position -= new Vector3(0.01f, 0, 0);
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
