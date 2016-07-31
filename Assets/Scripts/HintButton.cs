using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HintButton : MonoBehaviour
{

    public GameObject buyHintMenu;
    public GameObject hintScreen;
    public Text hintButtonText;
    public Text hintText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onHintButtonClick()
    {
        if (Saver.isHintBought() != 1)
        {
            buyHintMenu.SetActive(true);
        }
        else
        {
            hintScreen.SetActive(true);
            hintText.text = ScenesParameters.trueFunction;
            hintButtonText.text = LanguageManager.getLanguage().back;
        }
    }
}
