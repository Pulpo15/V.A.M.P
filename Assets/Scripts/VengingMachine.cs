using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VengingMachine : MonoBehaviour {

    public Rigidbody2D VendingMachine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        VendingMachine.velocity = new Vector3(0, 0, 0);
	}
}
