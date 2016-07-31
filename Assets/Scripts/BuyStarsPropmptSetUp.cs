using UnityEngine;
using System.Collections;

public class BuyStarsPropmptSetUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LanguageManager.setText("PromptText", LanguageManager.getLanguage().buy_stars_prompt);
        LanguageManager.setText("YesButtonText", LanguageManager.getLanguage().yes);
        LanguageManager.setText("NoButtonText", LanguageManager.getLanguage().no);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
