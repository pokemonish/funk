using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class StarScoreText : MonoBehaviour {

	public Text ScoreStartText;
	public Button Yes;
	public Button AddStar;
	public Text hintText;
	public GameObject hintWindow;

	void Update () {
		ScoreStartText.text = Shop.StarScore.ToString ();
		if (AddStar && Yes) {
			AddStar.gameObject.SetActive (!Shop.CanBuyHint ());
			Yes.gameObject.SetActive (Shop.CanBuyHint ());
		}
	}
	public void AddHint(){
		if (Shop.BuyHint()) {
			hintText.text = hintText.text.Replace ("{}", ScenesParameters.trueFunction);
			hintWindow.SetActive (true);
		}
	}
}
