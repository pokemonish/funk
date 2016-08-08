﻿using UnityEngine;
using System.Collections;

public class CompletedScripts : MonoBehaviour {

    public void Start()
    {
        LanguageManager.setText("Text_Completed", LanguageManager.getLanguage().completed);
        LanguageManager.setText("StarCountText", "+" + Shop.levelAward + " " + LanguageManager.getLanguage().stars);
    }

    public void replay()
    {
        CompletedScreen.getInstanse().SetActive(false);
        Application.LoadLevel(3);
    }

    public void continueGame()
    {
        CompletedScreen.getInstanse().SetActive(false);

        Debug.Log(ScenesParameters.CurrentLevel + 1);
        Debug.Log(ScenesParameters.LevelsNumber);

        if (ScenesParameters.LevelsNumber >= ScenesParameters.CurrentLevel + 1)
        {
            ScenesParameters.CurrentLevel++;
        }
        Application.LoadLevel(3);
    }
    
}
