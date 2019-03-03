using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamiaScript : MonoBehaviour {

    public float speed;

    private Transform target;
    
    // Use this for initialization
	void Start () {

		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


	}
	
	// Update is called once per frame
	void Update () {

        //cuando caleb toque algo, lamia persigue

        Perseguir();


    }
    

    void Perseguir ()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }


}
