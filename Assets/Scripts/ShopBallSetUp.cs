using UnityEngine;
using System.Collections;

public class ShopBallSetUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        LanguageManager.setText("BackButtonText", LanguageManager.getLanguage().back);
        LanguageManager.setText("TopInstructionText", LanguageManager.getLanguage().choose_ball + ' ' +
                                Shop.ballPrice + ' ' + LanguageManager.getLanguage().stars);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
