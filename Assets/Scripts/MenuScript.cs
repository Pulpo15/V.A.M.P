using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    private int numScene;
    public Animator animator;
    public Trigger trigger;
    

	// Use this for initialization
	void Start () {
		
	}

    
	
	// Update is called once per frame
	void Update () {
        if (trigger.Dialog == 24)
        {
            ChangeScene(3);
            
        }
        
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
        Application.Quit();
    }
}
