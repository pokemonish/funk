﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Tips : MonoBehaviour {

	[SerializeField]
	private GameObject [] tips_obj;
	[SerializeField]
	private Text text;
	[SerializeField]
	string [] ar;

    public GameObject tipsMain;
    public GameObject [] tipTexts;
    public GameObject [] tapTexts;

	// Use this for initialization
	void Start ()
	{
//		StartCoroutine (Tips1());
	    StartCoroutine(TipsAnimation());
	}

    IEnumerator TipsAnimation()
    {
        //bad practie
        var type = typeof(Language);

        int i = 0;

        bool firstIteration = true;

        while (true)
        {

            if (Input.anyKey || firstIteration)
            {
                firstIteration = false;

                Debug.Log("Next tip\n");

                if (i > 0) tips_obj[i - 1].SetActive(false);

                if (i == tips_obj.Length)
                {
                    if (Saver.hasShownTraining() != 1) Saver.dontShowTraining();
                    tipsMain.SetActive(false);
                    yield break;
                }

                tips_obj[i].SetActive(true);

                Debug.Log("tip text " + type.GetField("tip" + (i + 1)).GetValue(LanguageManager.getLanguage()).ToString());
                Debug.Log("tip1 " + LanguageManager.getLanguage().tip1);

                //bad practice
                LanguageManager.setText(tipTexts[i], type.GetField("tip" + (i + 1)).GetValue(LanguageManager.getLanguage()).ToString());
                LanguageManager.setText(tapTexts[i], LanguageManager.getLanguage().tap_to_continue);

                ++i;

                yield return new WaitForSeconds(4);

                Debug.Log("Waiting is over\n");

                tips_obj[i - 1].transform.FindChild("TapImage").gameObject.SetActive(true);
            }

            yield return null;
        }
    }
	
	/*void Update ()
	{
		if (tips [1])
		{

			if(text.text != "-<color=#E12F0BFF>2</color>") 
			{
				tips [1] = false;
				tips[2] = true;
				tips_obj [1].SetActive (false);
				tips_obj [2].SetActive (true);
		    }		
	    }
	}

	IEnumerator Tips1 ()
	{
		yield return new WaitForSeconds (5);
		tips_obj [0].SetActive (false);
		tips [1] = true;
		tips [0] = false;
		tips_obj [1].SetActive (true);

    }

    public void tips3(){
		if(tips[2]) tips_obj [2].SetActive (false);			
    }*/
}
