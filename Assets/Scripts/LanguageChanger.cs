using UnityEngine;
using System.Collections;

public class LanguageChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setEnglish()
    {
        LanguageManager.setLanguage("Eng");
    }

    public void setRussian()
    {
        LanguageManager.setLanguage("Rus");
    }
}
