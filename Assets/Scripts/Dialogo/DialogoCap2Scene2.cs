using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DialogoCap2Scene2 : MonoBehaviour {

    public Canvas Texto;
    public Canvas CanvasObjetivos;

    public Text VarTexto;
    public Text VarTitulo;
    public Text Objetvios;

    public Rigidbody2D Caleb;

    public ComprobadorMuertesLamia LamiaDead;

    //Var Time
    private readonly float timeToWait = 3.0f;
    private float timeToWaitCur;

    //Var Dialog
    private int Dialog = 0;

    //Boleans
    public bool isOnText;

    void Start () {
        Dialog = 0;
        CanvasObjetivos.enabled = false;
        Texto.enabled = false;
        timeToWaitCur = timeToWait;
        isOnText = true;
        Caleb.bodyType = RigidbodyType2D.Static;
    }
	
    void ShowText() {
        timeToWaitCur -= Time.deltaTime;
        if (isOnText && Dialog == 0 && timeToWaitCur <= 0) {
            Caleb.bodyType = RigidbodyType2D.Static;
            VarTexto.text = "Parece que aquí hay mas lamia de esos, tengo que ir con cuidado.";
            Texto.enabled = true;
            Dialog = 1;
        }
        else if (isOnText && Dialog == 1 && Input.GetKeyDown(KeyCode.Return)) {
            Objetvios.text = "Derrota a todos los lamia";
            CanvasObjetivos.enabled = true;
            Texto.enabled = false;
            isOnText = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Dialog = 2;
        }
        if (LamiaDead.allLamiaDead) { 
            Caleb.bodyType = RigidbodyType2D.Static;
            VarTexto.text = "Tengo que descubrir quien soy y porque. Lo que he hecho antes es inhumano pero por otra parte no soy como los lamia.";
            Texto.enabled = true;
            
        }
        if (LamiaDead.allLamiaDead && Input.GetKeyDown(KeyCode.Return)) {
            Objetvios.text = "Accede al siguiente nivel";
            Texto.enabled = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            LamiaDead.allLamiaDead = false;
        }
    }

	void Update () {
        ShowText();
	}
}
