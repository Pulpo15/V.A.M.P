using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour {

    public Rigidbody2D Caleb;
    public Rigidbody2D Cubos;

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Caleb")
        {
            ColisionCaleb();
        }
    }


    void ColisionCaleb()
    {
        if (Input.GetKey(KeyCode.E) == false)
        {
            if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y + 1);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 180))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y - 1f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 90))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x - 1, Caleb.position.y);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else
            {
                gameObject.transform.position = new Vector3(Caleb.position.x + 1, Caleb.position.y);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);

            }
        }
        else if (Input.GetKey(KeyCode.E) == true)
        {
            Cubos.velocity = new Vector3(0, 0, 0);
            Caleb.velocity = new Vector3(0, 0, 0);
            if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y + 1.1f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);

            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 180))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y - 1.1f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 90))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x - 1.1f, Caleb.position.y);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else
            {
                gameObject.transform.position = new Vector3(Caleb.position.x + 1.1f, Caleb.position.y);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
        }
    }
}
