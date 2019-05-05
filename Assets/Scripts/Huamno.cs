using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huamno : MonoBehaviour {

    public GameObject Rata;
    public Canvas RenderGris;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Caleb" && Input.GetKeyDown(KeyCode.Return))
        {
            RenderGris.enabled = false;
            Destroy(gameObject);
            Destroy(Rata);
        }
    }
}
