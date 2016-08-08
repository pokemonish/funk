using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScreenSetUp : MonoBehaviour
{

    public GameObject PlayButtonText;
    public GameObject OptionsButtonText;
    public GameObject ShopButtonText;
    public GameObject LogoImageText;

    // Use this for initialization
    void Start ()
	{
        if (LanguageManager.getLanguage() == null) LanguageManager.setLanguage("Eng");

	    LanguageManager.setText(PlayButtonText, LanguageManager.getLanguage().play);
        LanguageManager.setText(OptionsButtonText, LanguageManager.getLanguage().options);
        LanguageManager.setText(ShopButtonText, LanguageManager.getLanguage().shop);
        LanguageManager.setText(LogoImageText, LanguageManager.getLanguage().developer);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
