using UnityEngine;
using System.Collections;

public class LevelsSetUp : MonoBehaviour
{
    public GameObject BottomMenuButtonText;
    public GameObject loadingImage;

    // Use this for initialization
    void Start () {
        LanguageManager.setText("BottomMenuButtonText", LanguageManager.getLanguage().sections_menu);
    }
}
