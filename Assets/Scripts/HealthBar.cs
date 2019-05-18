using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Slider HpBar;
    public PasarVariables PasarVariable;


    // Use this for initialization
    void Start () {
        PasarVariable = GameObject.FindGameObjectWithTag("Variables").GetComponent<PasarVariables>();
        HpBar.value = PasarVariable.Vida;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
