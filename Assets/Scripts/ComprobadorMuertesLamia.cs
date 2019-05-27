using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobadorMuertesLamia : MonoBehaviour {

    public lamiaScript Lamia1;
    public lamiaScript Lamia2;
    public lamiaScript Lamia3;

    public bool allLamiaDead;
    int num;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Lamia1.isDead && Lamia2.isDead && Lamia3.isDead && num == 0)
        {
            allLamiaDead = true;
            num++;
        }
	}
}
