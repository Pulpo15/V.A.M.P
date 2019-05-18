using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasarVariables : MonoBehaviour {

    public Trigger Trigger;
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
		if (Trigger.Dialog == 24) {
            Repu = Reputacion.reputation;
            Vida = HpBar.value;
        }
	}
}
