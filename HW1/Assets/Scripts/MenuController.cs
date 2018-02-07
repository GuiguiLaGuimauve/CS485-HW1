using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    private int buttonWidth;
    private int buttonHeight;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
