using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIHandler : MonoBehaviour {
    public GameObject canvas;
    public Button inventoryButton;
    public Button resumeButton;
    public List<Button> buttons = new List<Button>();
    int focus = 0;

    // Use this for initialization
    void Start () {
		Button[] buttons = { inventoryButton, resumeButton };
	}
	
	// Update is called once per frame
	void Update () {
        Button currentButton = buttons[focus];

        currentButton.GetComponent<RectTransform>().anchorMax = new Vector2(20, 20);
       

        float upOrDown = Input.GetAxis("L_YAxis_1");

        if (upOrDown > 0.05f)
            upOnMenu(focus);
        else if (upOrDown < -0.05f)
            downOnMenu(focus);

	}

    public void setFocus(int focus)
    {
        this.focus = focus;
    }

    private static void upOnMenu(int focus)
    {
        if (focus == 2)
            focus = 0;
        else
            focus++;
    }

    private static void downOnMenu(int focus)
    {

    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        canvas.SetActive(false);
    }
}
