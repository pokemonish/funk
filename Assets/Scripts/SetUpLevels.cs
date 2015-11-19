using UnityEngine;
using System.Collections;
using System;

public class SetUpLevels : MonoBehaviour {

    public Camera cam;
    public Texture btnTexture;
    private GUIContent content = new GUIContent();

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {

        ScenesParameters.Devmode = false;

        content.image = btnTexture;

        var buttonSize = (new Vector3(Screen.width / 4f, Screen.width / 4f, 0f));
        
        for (int i = 1; i <= ScenesParameters.LevelsNumber; ++i)
        {
            content.text = "" + i;
            if (GUI.Button(new Rect(Screen.width * 0.25f - buttonSize.x / 2 + Screen.width / 2 * (1 - i % 2),
                Screen.width * 0.25f - buttonSize.x / 2 + buttonSize.y * 1.2f * 
                (float)Math.Ceiling((double)i / 2 - 1), buttonSize.x, buttonSize.y), content)) {
                ScenesParameters.CurrentLevel = i;
                Application.LoadLevel(3);
            }
        }
    }
}
