using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIHandler : MonoBehaviour {
    public GameObject canvas;
    
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      
	}

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        canvas.SetActive(false);
    }
}
