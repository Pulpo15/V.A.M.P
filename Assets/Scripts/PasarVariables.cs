using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasarVariables : MonoBehaviour {

    public Reputacion Reputacion;
    public Slider HpBar;
    public int Repu;
    public float Vida;
    public int Comprobador;

    // Use this for initialization
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    void Start () {
        Reputacion = GameObject.FindGameObjectWithTag("Player").GetComponent<Reputacion>();
        HpBar = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        Reputacion.reputation = Repu;
        HpBar.value = Vida;
	}
	
	// Update is called once per frame
	void Update () {
        Reputacion = GameObject.FindGameObjectWithTag("Player").GetComponent<Reputacion>();
        HpBar = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        if (Comprobador == 1) {
            Repu = Reputacion.reputation;
            Vida = HpBar.value;
            Comprobador = 0;
        }
        if (Comprobador == 2) {
            print("AWSd");
            Repu = Reputacion.reputation;
            Vida = HpBar.value;
            Comprobador = 0;
        }
	}
}
