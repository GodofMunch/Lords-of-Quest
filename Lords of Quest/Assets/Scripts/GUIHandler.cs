using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIHandler : MonoBehaviour {
    public GameObject canvas;
    public GameObject mainMenuPanel;
    public GameObject inventoryPanel;
    public Button inventoryButton;
    public Button resumeButton;
    public Button backButton;
    public List<Button> buttons = new List<Button>();
    public EventSystem myEvent; 

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
