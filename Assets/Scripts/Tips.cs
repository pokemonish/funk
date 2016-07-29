using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Tips : MonoBehaviour {

	[SerializeField]
	private bool[] tips;
	[SerializeField]
	private GameObject [] tips_obj;
	[SerializeField]
	private Text text;
	[SerializeField]
	string [] ar;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (Tips1());
	}
	
	void Update ()
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
			if(tips[2])
				tips_obj [2].SetActive (false);			
}
}
