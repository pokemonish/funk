using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyStarsPropmptSetUp : MonoBehaviour {

    public Button Yes;
    public Button AddStar;

    // Use this for initialization
    void Start () {
        LanguageManager.setText("PromptText", LanguageManager.getLanguage().buy_stars_prompt);
        LanguageManager.setText("NoButtonText", LanguageManager.getLanguage().no);

        if (Shop.CanBuyHint())
        {
            Yes.gameObject.SetActive(true);
            LanguageManager.setText("YesButtonText", LanguageManager.getLanguage().yes);
        }
        else
        {
            //AddStar.gameObject.SetActive (true);
            //LanguageManager.setText("AddStarsButtonText", LanguageManager.getLanguage().add);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
