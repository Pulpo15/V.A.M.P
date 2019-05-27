using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewLife : MonoBehaviour {

    public PasarVariables pasarVariable;
    public Huamno Humano;
    public Rata Rata;
    public Slider hpBar;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        pasarVariable.Vida = 10;
        Humano.vida = 10;
        Rata.vida = 10;
    }
}
