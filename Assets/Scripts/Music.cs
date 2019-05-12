using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    public AudioSource Pasos;

    // Use this for initialization
    void Start () {
		
	}

    void AudioPasos()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Pasos.Play();
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            Pasos.Stop();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Pasos.Play();
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            Pasos.Stop();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Pasos.Play();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Pasos.Stop();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Pasos.Play();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            Pasos.Stop();
        }
    }

	// Update is called once per frame
	void Update () {
        AudioPasos();
	}
}
