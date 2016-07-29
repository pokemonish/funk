using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class GameLnd : MonoBehaviour {

	public Text Run;
	public Text Menu;
	public Text Reset;
	public Text Yes;
	public Text No;
	public Text Add;
	public Text Thanks;
	public Text Hint;
	public Text Answer;
	public Text Hint1;
	public Text Hint2;
	public Text Hint3;
	private GameScene g;

	void Start () {
		g = Parse ();
		Run.text = g.Run;
		Menu.text = g.Menu;
		Reset.text = g.Reset;
		Yes.text = g.Yes;
		No.text = g.No;
		Add.text = g.Add;
		Thanks.text = g.Thanks;
		Answer.text = g.Answer;
		Hint.text = g.Hint;
		if (Hint1 && Hint2 && Hint3) {
			Hint1.text = g.Hint1;
			Hint2.text = g.Hint2;
			Hint3.text = g.Hint3;
		}

	}
	
	private GameScene Parse(){
		XmlSerializer serializer = new XmlSerializer (typeof(GameScene));
		TextAsset textAsset = (TextAsset)Resources.Load(
			"Lang/"+GameParametrs.Lang+
			'/' + "GameScene");

		System.IO.StringReader stringReader = new System.IO.StringReader(textAsset.text);
		System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stringReader);
		return (GameScene)serializer.Deserialize (reader);
	}
}
