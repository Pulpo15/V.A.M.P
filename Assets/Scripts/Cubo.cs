using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour {

    public Rigidbody2D Caleb;
    public Rigidbody2D Cubos;
    bool isTouching = false;
    //public bool isWalkingUp = false;
    //public bool isWalkingDowm = false;

    void Start () {
		
	}
	
	void Update () {
        Cubos.velocity = new Vector3(0, 0, 0);
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
        
        if (Input.GetKey(KeyCode.E) == false/* && isTouching == false*/)
        {
            isTouching = true;
            Cubos.velocity = new Vector3(0, 0, 0);
            Caleb.velocity = new Vector3(0, 0, 0);
            if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x + 1.13f, Caleb.position.y + 0.5f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 180, 0))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x - 1.13f, Caleb.position.y + 0.5f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0.1f))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x , Caleb.position.y + 2.2f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0.2f))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y - 0.6f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
        }
        else if (Input.GetKey(KeyCode.E) == true/*&& isTouching == true*/)
        {
            isTouching = false;
            Cubos.velocity = new Vector3(0, 0, 0);
            Caleb.velocity = new Vector3(0, 0, 0);
            if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x + 1.3f, Caleb.position.y + 0.5f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);

            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 180, 0))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x - 1.3f, Caleb.position.y + 0.5f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0.1f))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y + 2.25f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0.2f))
            {
                gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y - 0.65f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
        }
        else
        {
            Cubos.velocity = new Vector3(0, 0, 0);
        }
    }
}
