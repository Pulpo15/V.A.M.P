using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour {

    public Rigidbody2D Caleb;
    public Rigidbody2D Cubos;
    public bool[] isTouching = new bool[4];
  
    //public bool isWalkingUp = false;
    //public bool isWalkingDowm = false;

    void Start () {
		
	}
	
	void Update () {
        Cubos.velocity = new Vector3(0, 0, 0);
        ColisionCaleb();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Caleb")
        {
            CheckColisionCaleb();
        }
    }

    void ColisionCaleb()
    {
        if (isTouching[0])
        {
            //Izquierda
            gameObject.transform.position = new Vector3(Caleb.position.x + 1.3f, Caleb.position.y + 0.6f);
            gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
        }
        else if (isTouching[1])
        {
            //Derecha
            gameObject.transform.position = new Vector3(Caleb.position.x - 1.3f, Caleb.position.y + 0.6f);
            gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
        }
        else if (isTouching[2])
        {
            //Arriba
            gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y + 2.29f);
            gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
        }
        else if (isTouching[3])
        {
            //Abajo
            gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y - 0.6f);
            gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.E) == true)
        {
            if (isTouching[0])
            {
                isTouching[0] = false;
                gameObject.transform.position = new Vector3(Caleb.position.x + 1.3f, Caleb.position.y + 0.6f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (isTouching[1])
            {
                isTouching[1] = false;
                gameObject.transform.position = new Vector3(Caleb.position.x - 1.3f, Caleb.position.y + 0.6f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (isTouching[2])
            {
                isTouching[2] = false;
                gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y + 2.29f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (isTouching[3])
            {
                isTouching[3] = false;
                gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y - 0.6f);
                gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
        }
    }
    
    void CheckColisionCaleb()
    {
        
        if (Input.GetKey(KeyCode.E) == false/* && isTouching == false*/)
        {
            //isTouching = true;
            Cubos.velocity = new Vector3(0, 0, 0);
            Caleb.velocity = new Vector3(0, 0, 0);
            if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0))
            {
                //Derecha
                isTouching[0] = true;
                //gameObject.transform.position = new Vector3(Caleb.position.x + 1.13f, Caleb.position.y + 0.5f);
                //gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 180, 0))
            {
                //izquierda
                isTouching[1] = true;
            //    gameObject.transform.position = new Vector3(Caleb.position.x - 1.13f, Caleb.position.y + 0.5f);
            //    gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0.1f))
            {
                //Arriba
                isTouching[2] = true;
            //    gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y + 2.2643f);
            //    gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0.2f))
            {
                //Abajo
                isTouching[3] = true;
                //gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y - 0.6f);
                //gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
        }
        else if (Input.GetKey(KeyCode.E) == true/*&& isTouching == true*/)
        {
            //isTouching = false;
            Cubos.velocity = new Vector3(0, 0, 0);
            Caleb.velocity = new Vector3(0, 0, 0);
            if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0))
            {
                //gameObject.transform.position = new Vector3(Caleb.position.x + 1.3f, Caleb.position.y + 0.5f);
                //gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);

            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 180, 0))
            {
                //gameObject.transform.position = new Vector3(Caleb.position.x - 1.3f, Caleb.position.y + 0.5f);
                //gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0.1f))
            {
                //gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y + 2.29f);
                //gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
            else if (Caleb.transform.eulerAngles == new Vector3(0, 0, 0.2f))
            {
                //gameObject.transform.position = new Vector3(Caleb.position.x, Caleb.position.y - 0.65f);
                //gameObject.transform.eulerAngles = new Vector3(Caleb.transform.eulerAngles.x, Caleb.transform.eulerAngles.y, Caleb.transform.eulerAngles.z);
            }
        }
        else
        {
            Cubos.velocity = new Vector3(0, 0, 0);
        }
    }
}
