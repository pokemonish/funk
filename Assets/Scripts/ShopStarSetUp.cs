using UnityEngine;
using System.Collections;

public class ShopStarSetUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LanguageManager.setText("AddStarsText", LanguageManager.getLanguage().add + " 10 " + LanguageManager.getLanguage().stars);
        LanguageManager.setText("BackButtonText", LanguageManager.getLanguage().back);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
