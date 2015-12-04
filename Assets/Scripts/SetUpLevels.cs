using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class SetUpLevels : MonoBehaviour {

    public GUISkin MainFunkButton;
    public Camera cam;
    public Texture btnTexture;
    public Texture lockTexture;
    public float offset = 0;
    
    private GUIContent content = new GUIContent();
    private Scrollbar scrollBar;

	// Use this for initialization
	void Start () {
        var scrollbarGO = GameObject.Find("LevelScrollbar");
        scrollBar = scrollbarGO.GetComponent<Scrollbar>();

        float levelsHeight = (ScenesParameters.LevelsNumber / 2 + 2) * Screen.width * 0.25f;

        if (levelsHeight < Screen.height)
        {
            GameObject.Find("UserUICanvas").SetActive(false);
        } else
        {
            scrollBar.size = 0.33f/*Screen.height / levelsHeight*/;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setScrollBarOffset()
    {
        offset = scrollBar.value * ScenesParameters.LevelsNumber / 2 * Screen.width * 0.25f;
    }

    void OnGUI()
    {
        GUI.skin = MainFunkButton;

        var buttonSize = (new Vector2(Screen.width * 0.4f, Screen.width * 0.4f));
        var lockSize = new Vector2(buttonSize.x * 0.6f, buttonSize.y * 0.6f);

        int i = 1;
        while (Saver.isLevelPlayable(i) && i <= ScenesParameters.LevelsNumber)
        {
            var buttonPosisiton = 
                new Vector2(Screen.width * 0.25f - buttonSize.x / 2 + Screen.width / 2 * (1 - i % 2),
                            Screen.width * 0.25f - buttonSize.x / 2 + buttonSize.y * 1.2f *
                            (float)Math.Ceiling((double)i / 2 - 1) - offset);
            content.text = "" + i;

            var button = GUI.Button(new Rect(buttonPosisiton, buttonSize), content);
            if (button)
            {
                ScenesParameters.CurrentLevel = i;
                Application.LoadLevel(3);
            }

            ++i;
        }

        Vector2 currentSize;
        if(i % 2 == 0)
        {
            currentSize = lockSize;
        } else
        {
            currentSize = buttonSize;
        }

        for (int j = i; j <= ScenesParameters.LevelsNumber; ++j)
        {

            var buttonPosisiton = 
                new Vector2(Screen.width * 0.25f - lockSize.x / 2 + Screen.width / 2 * (1 - j % 2),
                            Screen.width * 0.25f - currentSize.x / 2 + currentSize.y * 1.2f *
                            (float)Math.Ceiling((double)j / 2 - 1) - offset);

            GUI.DrawTexture(new Rect(buttonPosisiton, lockSize), lockTexture);
            currentSize = buttonSize;
        }
    }
}
