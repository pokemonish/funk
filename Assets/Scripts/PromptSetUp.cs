using UnityEngine;
using System.Collections;

public class PromptSetUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LanguageManager.setText("PromptText", LanguageManager.getLanguage().buy_stars_prompt);
        LanguageManager.setText("NoButtonText", LanguageManager.getLanguage().no);
        LanguageManager.setText("YesButtonText", LanguageManager.getLanguage().yes);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
