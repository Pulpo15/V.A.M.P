using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogoCap2 : MonoBehaviour
{

    //GameObjects
    public Canvas Texto;
    public Canvas CanvasObjetivos;
    public Canvas DiarioLamia;

    public Text VarTexto;
    public Text VarTitulo;
    public Text Objetvios;

    public Rigidbody2D Caleb;

    public Collider2D CientificoMuerto;
    public Collider2D ColliderDiarioLamia;
    public Collider2D TriggerPuertaSalaContro;
    public Collider2D TriggerTarjetaSalaControl;
    public Collider2D ColCajaGas;

    public lamiaScript Lamia;

    public SpriteRenderer SpriteDiarioLamia;
    public SpriteRenderer SpriteTarjetaSalaControl;
    public SpriteRenderer SpriteCajaGas;
    
    //Var Time
    private readonly float timeToWait = 3.0f;
    private float timeToWaitCur;
    private readonly float timeBetweenScenes = 5;
    private float timeBetweenScenesCur;
    
    //Var Dialog
    private int Dialog = 0;
    
    //Boleans
    public bool isOnText;
    private bool dialogoCientifico;
    private bool dialogoGas;
    private bool dialogoLamia;
    private bool dialogoDiarioLamia;
    private bool dialogoPuertaSalaControl;
    private bool keySalaControl;
    private bool gasOut;

    private void Start() {
        Dialog = 0;
        CanvasObjetivos.enabled = false;
        Texto.enabled = false;
        timeToWaitCur = timeToWait;
        timeBetweenScenesCur = timeBetweenScenes;
        isOnText = true;
        Caleb.bodyType = RigidbodyType2D.Static;
    }

    private void Update() {
        ShowText();
        print(Dialog);
    }

    void ShowText() {
        timeToWaitCur -= Time.deltaTime;
        //Dialogo Inicial
        if (isOnText && Dialog == 0 && timeToWaitCur <= 0) {
            Caleb.bodyType = RigidbodyType2D.Static;
            VarTexto.text = "*Bleh*";
            Texto.enabled = true;
            Dialog = 1;
        }
        else if (isOnText && Dialog == 1 && Input.GetKeyDown(KeyCode.Return)) {
            VarTexto.text = "Que sitio más asqueroso";
            Dialog = 2;
        }
        else if (isOnText && Dialog == 2 && Input.GetKeyDown(KeyCode.Return)) {
            Objetvios.text = "Encuentra la manera de llegar al laboratorio";
            CanvasObjetivos.enabled = true;
            Texto.enabled = false;
            isOnText = false;
            Dialog = 3;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
        }
        //Dialogo Inicial
        //Dialogo Cientifico Muerto
        if (dialogoCientifico && isOnText && Dialog == 3) {
            Caleb.bodyType = RigidbodyType2D.Static;
            VarTexto.text = "Las heridas de este científico son muy raras, dos perforaciones circulares. ¿Dónde he escuchado yo eso?";
            CientificoMuerto.enabled = false;
            Texto.enabled = true;
            Dialog = 4;
        }
        else if (dialogoCientifico && isOnText && Input.GetKeyDown(KeyCode.Return) && Dialog == 4) {
            VarTexto.text = "Parece que tiene una nota";
            Dialog = 5;
        }
        else if (dialogoCientifico && isOnText && Input.GetKeyDown(KeyCode.Return) && Dialog == 5) {
            VarTitulo.text = "Nota";
            VarTexto.text = "Esto se nos ha ido de las manos, ha creado un ser monstruoso que ni siquiera nosotros sabemos de que es capaz. Desde que comenzamos con las pruebas del suero. ";
            Dialog = 6;
        }
        else if (dialogoCientifico && isOnText && Input.GetKeyDown(KeyCode.Return) && Dialog == 6) {
            VarTexto.text = "Los sujetos empezaban a perder capacidad visual y la conciencia, tanto que se volvían agresivos. Si no la paramos la seguridad civil se verá en peligro.";
            Dialog = 7;
        }
        else if (dialogoCientifico && isOnText && Input.GetKeyDown(KeyCode.Return) && Dialog == 7) {
            VarTexto.text = "He decidido sacar a la luz sus experimentos, tengo que encontrar la manera de salir de laboratorio, voy a usar el antiguo alcantarillado.";
            Dialog = 8;
        }
        else if (dialogoCientifico && isOnText && Input.GetKeyDown(KeyCode.Return) && Dialog == 8) {
            VarTexto.text = "Aunque por la edad que tienen las tuberías estarán bastante deterioradas. Si quiero pasar por ahí tendré que llevar algo para obstruir el gas tóxico.";
            Dialog = 9;
        }
        else if (dialogoCientifico && isOnText && Input.GetKeyDown(KeyCode.Return) && Dialog == 9) {
            VarTitulo.text = "Caleb";
            VarTexto.text = "Esto si que es raro, este científico quería sacar a la luz algo que no se tenía que saber. A saber que le ha pasado. ¿Qué o quién puede causar estas heridas?";
            Dialog = 10;
        }
        else if (dialogoCientifico && isOnText && Input.GetKeyDown(KeyCode.Return) && Dialog == 10) {
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            dialogoCientifico = false;
            isOnText = false;
            Texto.enabled = false;
            Dialog = 11;
        }
        //Dialogo Cientifico Muerto
        if (dialogoGas && isOnText && Dialog == 11) {
            Caleb.bodyType = RigidbodyType2D.Static;
            Texto.enabled = true;
            VarTexto.text = "En el diario del científico decía que las tuberías estaban en mal estado y que debería traer algo para bloquearlas, seguro que por aquí encuentro algo para bloquearlas.";
            Dialog = 12;
        }
        if (dialogoGas && isOnText && Dialog == 12 && Input.GetKeyDown(KeyCode.Return)) {
            Objetvios.text = "Busca algo para bloquear el gas tóxico";
            ColCajaGas.enabled = true;
            SpriteCajaGas.enabled = true;
            Texto.enabled = false;
            dialogoGas = false;
            isOnText = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Dialog = 13;
        }
        if (gasOut)
        {
            Objetvios.text = "Encuentra una manera de llegar al laboratorio";
            gasOut = false;
        }
        if (dialogoLamia && isOnText && Dialog == 13) {
            Caleb.bodyType = RigidbodyType2D.Static;
            Texto.enabled = true;
            VarTexto.text = "Algo se acerca";
            Dialog = 14;
        }
        if (dialogoLamia && isOnText && Input.GetKeyDown(KeyCode.Return) && Dialog == 14) {
            VarTexto.text = "*Usa espacio para usar el Dash*";
            Dialog = 15;
        }
        else if (dialogoLamia && isOnText && Input.GetKeyDown(KeyCode.Return) && Dialog == 15) {
            VarTexto.text = "*Embiste 2 veces al Lamia usando el Dash para acabar con el*";
            Dialog = 16;
        }
        else if (dialogoLamia && isOnText && Input.GetKeyDown(KeyCode.Return) && Dialog == 16) {
            Objetvios.text = "Acaba con el Lamia";
            Texto.enabled = false;
            dialogoLamia = false;
            isOnText = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Dialog = 17;
        }
        if (Lamia.isDead && Dialog == 17) {
            Caleb.bodyType = RigidbodyType2D.Static;
            Texto.enabled = true;
            Dialog = 18;
            VarTexto.text = "Que narices era eso, seguro que está relacionado con la muerte del científico y los ataques";
        }
        else if (Lamia.isDead && Dialog == 18 && Input.GetKeyDown(KeyCode.Return)) {
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Texto.enabled = false;
            Lamia.isDead = false;
            Dialog = 19;
        }
        if (dialogoDiarioLamia && isOnText) {
            Caleb.bodyType = RigidbodyType2D.Static;
            DiarioLamia.enabled = true;
            SpriteDiarioLamia.enabled = false;
            ColliderDiarioLamia.enabled = false;
        }
        if (dialogoDiarioLamia && isOnText && Input.GetKeyDown(KeyCode.Return)) {
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            DiarioLamia.enabled = false;
            dialogoDiarioLamia = false;
            isOnText = false;
        }
        if (dialogoPuertaSalaControl && !keySalaControl && isOnText) {
            Caleb.bodyType = RigidbodyType2D.Static;
            Texto.enabled = true;
            VarTexto.text = "Parece que necesito una tarjeta para acceder a la sala de control";
            Objetvios.text = "Consigue acceder a la sala de Control";
            TriggerPuertaSalaContro.enabled = false;
        }
        if (dialogoPuertaSalaControl && !keySalaControl && isOnText && Input.GetKeyDown(KeyCode.Return)) {
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Texto.enabled = false;
            dialogoPuertaSalaControl = false;
            isOnText = true;
        }
        if (keySalaControl && isOnText) {
            Caleb.bodyType = RigidbodyType2D.Static;
            Texto.enabled = true;
            VarTexto.text = "Parece la tarjeta para acceder a la sala de control";
            TriggerTarjetaSalaControl.enabled = false;
            SpriteTarjetaSalaControl.enabled = false;
        }
        if (keySalaControl && isOnText && Input.GetKeyDown(KeyCode.Return)) {
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Objetvios.text = "Accede a la sala de control";
            Texto.enabled = false;
            isOnText = false;
        }


    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "CientificoMuerto") {
            isOnText = true;
            dialogoCientifico = true;
        }
        if (collision.gameObject.name == "Gas") {
            dialogoGas = true;
            isOnText = true;
        }
        if (collision.gameObject.name == "TriggerDiaologo") {
            dialogoLamia = true;
            isOnText = true;
        }
        if (collision.gameObject.name == "DiarioLamia") {
            dialogoDiarioLamia = true;
            isOnText = true;
        }
        if (collision.gameObject.name == "PuertaSalaControl") {
            dialogoPuertaSalaControl = true;
            isOnText = true;
        }
        if (collision.gameObject.name == "TarjetaSalaControl") {
            keySalaControl = true;
            isOnText = true;
        }
        if (collision.gameObject.name == "TriggerGasOut") {
            gasOut = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

}