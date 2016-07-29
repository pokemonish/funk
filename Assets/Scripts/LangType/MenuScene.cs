using UnityEngine;
using System.Collections;
using System.Xml.Serialization;


[XmlRoot("Menu")]
public class MenuScene  {

	public MenuScene(){}

	public MenuScene(string menu,string linear,string power,string root,string exponental,string hyperbolic,string logarithm,string mixed,string polinomial,string special,string trigonometric){

		this.Menu = menu;
		this.Linear = linear;
		this.Power = power;
		this.Root = root;
		this.Exponential = exponental;
		this.Hyperbolic = hyperbolic;
		this.Logarithm = logarithm;
		this.Mixed = mixed;
		this.Polinomial = polinomial;
		this.Special = special;
		this.Trigonometric = trigonometric;
	
	}

	[XmlElement("Menu")]
	public string Menu{ get; set;}

	[XmlElement("Linear")]
	public string Linear{ get; set;}

	[XmlElement("Power")]
	public string Power{ get; set;}

	[XmlElement("Root")]
	public string Root{ get; set;}

	[XmlElement("Exponential")]
	public string Exponential{ get; set;}

	[XmlElement("Hyperbolic")]
	public string Hyperbolic{ get; set;}

	[XmlElement("Logarithm")]
	public string Logarithm{ get; set;}

	[XmlElement("Mixed")]
	public string Mixed{ get; set;}

	[XmlElement("Polinomial")]
	public string Polinomial{ get; set;}

	[XmlElement("Special")]
	public string Special{ get; set;}

	[XmlElement("Trigonometric")]
	public string Trigonometric{ get; set;}

}
