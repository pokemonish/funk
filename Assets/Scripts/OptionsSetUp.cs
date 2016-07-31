using UnityEngine;
using System.Collections;

public class OptionsSetUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LanguageManager.setText("DeleteProgressText", LanguageManager.getLanguage().delete_progress);
        LanguageManager.setText("BackButtonText", LanguageManager.getLanguage().back);
        LanguageManager.setText("Dev1NameText", LanguageManager.getLanguage().name_1);
        LanguageManager.setText("Dev2NameText", LanguageManager.getLanguage().name_2);
        LanguageManager.setText("Dev3NameText", LanguageManager.getLanguage().name_3);
        LanguageManager.setText("Dev1PositionText", LanguageManager.getLanguage().position_1);
        LanguageManager.setText("Dev2PositionText", LanguageManager.getLanguage().position_2);
        LanguageManager.setText("Dev3PositionText", LanguageManager.getLanguage().position_3);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
