using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Trigger : MonoBehaviour
{

    //public Dialogo dialogo;
    public Canvas Texto;
    public Canvas CanvasObjetivos;
    public Canvas Diario1;
    public Canvas Diario2;
    public Canvas Diario3;
    public Canvas RenderGris;
    public Canvas Transition;
    public Text VarTexto;
    public Text VarTitulo;
    public Text Objetvios;
    public bool isOnText = true;
    public bool textTime = false;
    private readonly float timeToWait = 3.0f;
    private float timeToWaitCur;
    public int Dialog = 0;
    public Rigidbody2D Caleb;
    public SpriteRenderer SpriteDiario;
    public SpriteRenderer SpriteDiario2;
    public SpriteRenderer SpriteDiario3;
    public bool dialogoLlave = false;
    public int dialogoCaja = 1;
    public bool dialogoPuerta = false;
    public bool haveKey = false;
    public bool diaologoSalir = false;
    public Collider2D salirAlmacen;
    private bool isOnHome;
    private bool isOnLight;
    private bool diario3;
    private bool tlf;
    private bool entradaCloacas;
    public Animator animator;
    public Animator cloacas;
    public Animator transicion;
    public readonly float timeBetweenScenes = 5;
    public float timeBetweenScenesCur;
    public Tilemap PuertaAlmacen1;


    private void Start()
    {
        CanvasObjetivos.enabled = false;
        Texto.enabled = false;
        Diario1.enabled = false;
        timeToWaitCur = timeToWait;
        isOnText = true;
        Caleb.bodyType = RigidbodyType2D.Static;
        timeBetweenScenesCur = timeBetweenScenes;
    }

    private void Update()
    {
        ShowText();
        timeBetweenScenesCur -= Time.deltaTime;
        if (timeBetweenScenesCur <= 0 && Dialog == 24)
        {
            SceneManager.LoadScene(3);
            transicion.SetBool("changeScene", false);
        }

    }

    void ShowText()
    {
        timeToWaitCur -= Time.deltaTime;
        //Texto AfterWakeUp
        if (isOnText == true && Dialog == 0 && timeToWaitCur <= 0)
        {
            Caleb.bodyType = RigidbodyType2D.Static;
            VarTexto.text = "¿Donde estoy? ¿Cuanto tiempo he dormido?";
            Texto.enabled = true;
            Dialog = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && Dialog == 1 && isOnText)
        {
            VarTexto.text = "¿Y mis padres? No me encuentro nada bien.";
            Dialog = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && Dialog == 2 && isOnText)
        {
            Texto.enabled = false;
            isOnText = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            textTime = false;
            Objetvios.text = "Explora el Almacén";
            CanvasObjetivos.enabled = true;
            Dialog = 3;
        }
        //Texto Diario
        if (Dialog == 3 && isOnText)
        {
            Caleb.bodyType = RigidbodyType2D.Static;
            Diario1.enabled = true;
            SpriteDiario.enabled = false;
            Dialog = 4;
        }
        else if (Dialog == 4 && Input.GetKeyDown(KeyCode.Return) && isOnText)
        {
            PuertaAlmacen1.transform.position += new Vector3(0,0,20);
            Diario1.enabled = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Dialog = 5;
            isOnText = false;
        }
        //Texto Salir Primera Habitación
        if (Dialog == 5 && isOnText)
        {
            Caleb.bodyType = RigidbodyType2D.Static;
            VarTexto.text = "Debería salir de este almacén y pedir ayuda.";
            Texto.enabled = true;
            Dialog = 6;
        }
        else if (Dialog == 6 && Input.GetKeyDown(KeyCode.Return) && isOnText)
        {
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Texto.enabled = false;
            Dialog = 8;
            Objetvios.text = "Encuentra una Salida";
            isOnText = false;
        }
        //Dialogo Llave
        if (dialogoLlave)
        {
            VarTexto.text = "Seguro que esta llave sirve para algo.";
            Objetvios.text = "Usa la llave para salir del Almacén";
            Texto.enabled = true;
            Caleb.bodyType = RigidbodyType2D.Static;
        }
        if (dialogoLlave && Input.GetKeyDown(KeyCode.Return))
        {
            Texto.enabled = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            dialogoLlave = false;
        }
        //Dialogo Caja
        if (dialogoCaja == 2 && isOnText)
        {
            VarTexto.text = "Parece que puedo mover esa caja\n(Pulsa E para soltar la caja)";
            Texto.enabled = true;
            Caleb.bodyType = RigidbodyType2D.Static;
        }
        if (dialogoCaja == 2 && isOnText && Input.GetKeyDown(KeyCode.Return))
        {
            Texto.enabled = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            isOnText = false;
            dialogoCaja++;
        }
        //Dialogo Puerta
        if (dialogoPuerta && Input.GetKeyDown(KeyCode.Return))
        {
            Texto.enabled = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            dialogoPuerta = false;
        }
        //Dialogo Salir Almacén
        if (isOnText && diaologoSalir && Dialog == 8)
        {
            salirAlmacen.enabled = false;
            VarTexto.text = "*Uhhhh*";
            Texto.enabled = true;
            Caleb.bodyType = RigidbodyType2D.Static;
            Dialog = 9;
        }
        if (isOnText && diaologoSalir && Input.GetKeyDown(KeyCode.Return) && Dialog == 9)
        {
            VarTexto.text = "¡Debo apresurarme y buscar ayuda ya!";
            Dialog = 10;
            Objetvios.text = "Busca ayuda";
        }
        else if (isOnText && diaologoSalir && Input.GetKeyDown(KeyCode.Return) && Dialog == 10)
        {
            Texto.enabled = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            isOnText = false;
            diaologoSalir = false;
            Dialog = 11;
        }
        if (isOnText && Dialog == 11)
        {
            Diario2.enabled = true;
            SpriteDiario2.enabled = false;
            Caleb.bodyType = RigidbodyType2D.Static;
        }
        if (isOnText && Dialog == 11 && Input.GetKey(KeyCode.Return))
        {
            Diario2.enabled = false;
            Texto.enabled = true;
            VarTexto.text = "No se que esta pasando, tengo mucha sed.";
            Objetvios.text = "Aliméntate de un humano o una rata.";
            Dialog = 12;
            print("asd");
        }
        else if (isOnText && Dialog == 12 && Input.GetKeyDown(KeyCode.Return))
        {
            VarTexto.text = "(Aliméntate de un humano o una rata, tu elección repercutirá en el futuro, acércate a tu elección y pulsa intro).";
            Dialog = 13;
        }
        else if (isOnText && Dialog == 13 && Input.GetKeyDown(KeyCode.Return))
        {
            Texto.enabled = false;
            isOnText = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Dialog = 14;
        }
        if (isOnText && Dialog == 14 && isOnHome)
        {
            Texto.enabled = true;
            VarTexto.text = "Que me está pasando, yo no quería hacer eso";
            Caleb.bodyType = RigidbodyType2D.Static;
            Dialog = 15;
        }
        else if (isOnText && Dialog == 15 && Input.GetKeyDown(KeyCode.Return) && isOnHome)
        {
            Objetvios.text = "Accede al segundo piso";
            Dialog = 16;
            VarTexto.text = "Ya se está haciendo de día, seguro que encuentro ayuda en esta casa";
        }
        else if (isOnText && Dialog == 16 && Input.GetKeyDown(KeyCode.Return) && isOnHome)
        {
            Texto.enabled = false;
            isOnHome = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Dialog = 17;
        }
        if (diario3 && Dialog == 17)
        {
            Diario3.enabled = true;
            Caleb.bodyType = RigidbodyType2D.Static;
        }
        if (diario3 && Input.GetKeyDown(KeyCode.Return) && Dialog == 17)
        {
            Diario3.enabled = false;
            SpriteDiario3.enabled = false;
            diario3 = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Dialog = 18;
        }
        if (isOnText && Dialog == 18 && isOnLight)
        {
            Texto.enabled = true;
            VarTexto.text = "Tengo que encontrar algo para bloquear la luz";
            Caleb.bodyType = RigidbodyType2D.Static;
        }
        if (isOnText && Dialog == 18 && Input.GetKeyDown(KeyCode.Return) && isOnLight)
        {
            Texto.enabled = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Dialog = 19;
        }
        if (tlf && Dialog == 19)
        {
            VarTitulo.text = "????";
            VarTexto.text = "Veo que ya estas despierto. Seguramente tienes muchas preguntas. Todo a su debido tiempo";
            Texto.enabled = true;
            Caleb.bodyType = RigidbodyType2D.Static;
            Dialog = 20;
        }
        else if (tlf && Dialog == 20 && Input.GetKeyDown(KeyCode.Return))
        {
            VarTexto.text = "Si tanto quieres saber ve al laboratorio, supongo que ya sabes dónde se encuentra.";
            Objetvios.text = "Accede a las cloacas";
            Dialog = 21;
        }
        else if (tlf && Dialog == 21 && Input.GetKeyDown(KeyCode.Return))
        {
            Texto.enabled = false;
            tlf = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Dialog = 22;
        }
        if(entradaCloacas && Dialog == 22)
        {
            cloacas.SetBool("isOpen", true);
            VarTitulo.text = "Caleb";
            VarTexto.text = "Bien si eso es lo quieres iré hacia el laboratorio.";
            Texto.enabled = true;
            Caleb.bodyType = RigidbodyType2D.Static;
            Dialog = 23;
            
        }
        else if (entradaCloacas && Dialog == 23 && Input.GetKeyDown(KeyCode.Return))
        {
            Texto.enabled = false;
            entradaCloacas = false;
            Caleb.bodyType = RigidbodyType2D.Dynamic;
            Dialog = 24;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Diario" && Dialog == 3)
        {
            isOnText = true;
        }
        if (col.gameObject.name == "SalirHabitación")
        {
            isOnText = true;
        }
        if (col.gameObject.name == "Llave")
        {
            dialogoLlave = true;
            haveKey = true;
        }
        if (col.gameObject.name == "SalirAlmacén")
        {
            isOnText = true;
            diaologoSalir = true;
            RenderGris.enabled = true;
            animator.SetBool("haSalido", true);

        }
        if (col.gameObject.name == "Diario2")
        {
            isOnText = true;
        }
        if (col.gameObject.name == "EntradaCasa")
        {
            isOnText = true;
            isOnHome = true;
        }
        if (col.gameObject.name == "Luz")
        {
            isOnText = true;
            isOnLight = true;
        }
        if (col.gameObject.name == "Diario3")
        {
            diario3 = true;
        }
        if (col.gameObject.name == "Telefono")
        {
            tlf = true;
        }
        if (col.gameObject.name == "EntradaCloacas" && Dialog == 22)
        {
            entradaCloacas = true;
        }
        if (col.gameObject.name == "CambiarCap" && Dialog == 24)
        {
            //Transition.enabled = true;
            transicion.SetBool("changeScene", true);
            timeBetweenScenesCur = timeBetweenScenes;
        }
        //if (col.gameObject.name == "Puerta")
        //{
        //    BoxPuerta1.size = new Vector3(1, 2.217735f, 1);
        //}
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Cubo")
        {
            dialogoCaja++;
            isOnText = true;
        }
        if (col.gameObject.name == "Puerta" && !haveKey)
        {
            //isOnText = true;
            //BoxPuerta1.size = new Vector3(0.4205475f, 2.217735f, 1);
            //BoxPuerta1.size = new Vector3(1, 2.217735f, 1);
            //Puerta1.localScale = new Vector3(1, 2.217735f, 1);
            dialogoPuerta = true;
            VarTexto.text = "Parece cerrada, voy a necesitar algo para abrirla";
            Texto.enabled = true;
            //Caleb.bodyType = RigidbodyType2D.Static;
            //Puerta1.localScale = new Vector3(0.4205475f, 2.217735f, 1);
        }
        
    }

}