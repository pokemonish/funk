using UnityEngine;
using System.Collections;
using System.Xml.Serialization;


[XmlRoot("Game")]
public class GameScene  {

	public GameScene(){}

	public GameScene(string run,string menu,string reset,string yes,string no,string add,string thanks,string hint,string answer,string hint1,string hint2,string hint3){
		this.Run = run;
		this.Menu = menu;
		this.Reset = reset;
		this.Yes = yes;
		this.No = no;
		this.Add = add;
		this.Thanks = thanks;
		this.Hint = hint;
		this.Answer = answer;
		this.Hint1 = hint1;
		this.Hint2 = hint2;
		this.Hint3 = hint3;
	}

	[XmlElement("Run")]
	public string  Run {get;set;}

	[XmlElement("Menu")]
	public string  Menu {get;set;}

	[XmlElement("Reset")]
	public string Reset {get;set;}

	[XmlElement("Yes")]
	public string  Yes {get;set;}

	[XmlElement("No")]
	public string No  {get;set;}

	[XmlElement("Add")]
	public string Add  {get;set;}

	[XmlElement("Thanks")]
	public string Thanks  {get;set;}

	[XmlElement("Hint")]
	public string Hint  {get;set;}

	[XmlElement("Answer")]
	public string Answer {get;set;}

	[XmlElement("Hint1")]
	public string Hint1  {get;set;}

	[XmlElement("Hint2")]
	public string  Hint2 {get;set;}

	[XmlElement("Hint3")]
	public string  Hint3 {get;set;}

}

