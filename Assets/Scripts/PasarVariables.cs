using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasarVariables : MonoBehaviour {

    public Trigger Trigger;
    public DialogoCap2 DialogoCap2;
    public Reputacion Reputacion;
    public Slider HpBar;
    public int Repu;
    public float Vida;

    // Use this for initialization
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    void Start () {
        Reputacion.reputation = Repu;
        HpBar.value = Vida;
	}
	
	// Update is called once per frame
	void Update () {
        DialogoCap2 = GameObject.FindGameObjectWithTag("Player").GetComponent<DialogoCap2>();
        Reputacion = GameObject.FindGameObjectWithTag("Player").GetComponent<Reputacion>();
        HpBar = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        if (Trigger.Dialog == 24) {
            Repu = Reputacion.reputation;
            Vida = HpBar.value;
        }
        if (DialogoCap2.exit) {
            print("AWSd");
            Repu = Reputacion.reputation;
            Vida = HpBar.value;
        }
	}
}
