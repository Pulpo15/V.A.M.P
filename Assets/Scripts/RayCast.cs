using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

    public Transform RCBeg, RCEnd;

    

	// Use this for initialization
	void Start () {
		
	}
	void Raycasting ()
    {
        Debug.DrawLine(RCBeg.position, RCEnd.position, Color.black);
    }
	// Update is called once per frame
	void Update () {

        Raycasting();
	}
}
