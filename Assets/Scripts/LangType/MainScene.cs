using UnityEngine;
using System.Collections;
using System.Xml.Serialization;


[XmlRoot("Main")]
public class MainScene{

	public MainScene(){}


	public MainScene(string play,string menu,string options,string moreStars,string shop){
		this.Play = play;
		this.Menu = menu;
		this.Options = options;
        this.MoreStars = moreStars;
        this.Shop = shop;
	}

	[XmlElement("Play")]
	public string Play{ get; set;}

	[XmlElement("Menu")]
	public string Menu{ get; set;}

	[XmlElement("Options")]
	public string Options{ get; set;}

    [XmlElement("Shop")]
    public string Shop { get; set; }

    [XmlElement("MoreStars")]
    public string MoreStars { get; set; }
}
