using UnityEngine;
using System.Collections;
using System.Xml.Serialization;


[XmlRoot("Shop")]
public class ShopScene{

	public ShopScene(){}

	public ShopScene(string cOntinue,string buy){
		this.Continue = cOntinue;
		this.Buy = buy;
	}

	[XmlElement("Continue")]
	public string Continue {get;set;}

	[XmlElement("isBought")]
	public string Buy {get;set;}

}
