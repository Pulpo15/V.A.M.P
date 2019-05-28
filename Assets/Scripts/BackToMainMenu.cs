using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
        }
	}
}
