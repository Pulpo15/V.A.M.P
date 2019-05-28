using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    private int numScene;
    public Animator animator;
    public Trigger trigger;
    string sceneName;

    // Use this for initialization
    void Start () {
        sceneName = PlayerPrefs.GetString("lastLoadedScene");
    }

    
	
	// Update is called once per frame
	void Update () {

        print(sceneName);
    }

    public void ChangeToStory()
    {
        if (sceneName == "")
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(sceneName);
    }


    public void ChangeScene(int indexScene)
    {
        numScene = indexScene;
        animator.SetBool("isChanging", true);
        
    }

    public void LevelComplete()
    {
        SceneManager.LoadScene(numScene);
       
    }


    public void Exit()
    {
        PlayerPrefs.SetString("lastLoadedScene", "");
        Application.Quit();
    }
}
