﻿using System;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
public class Language
{
    //several screens
    public string sections_menu;
    public string shop;
    public string yes;
    public string no;
    public string thanks;
    public string back;

    //main screen
    public string options;
    public string play;
    public string developer;

    //sections screen
    public string main_screen;
    public string linear;
    public string power;
    public string root;
    public string logarithm;
    public string exponental;
    public string trigonometric;
    public string polinomial;
    public string hyperbolic;
    public string mixed;
    public string special;
    public string coming_soon;

    //game screen
    public string reset;
    public string run;
    public string completed;
    public string stars;
    public string buy_stars_prompt;
    public string tap_to_continue;
    public string tip1;
    public string tip2;
    public string tip3;
    public string tip4;

    //shop
    public string choose_ball;

    //options
    public string delete_progress;
    public string name_1;
    public string position_1;
    public string name_2;
    public string position_2;
    public string name_3;
    public string position_3;

    //star shop
    public string add;
}


[XmlRoot("Language")]
public class LanguageXml
{
    //several screens
    [XmlElement("sections_menu")]
    public string sections_menu;
    [XmlElement("shop")]
    public string shop;
    [XmlElement("yes")]
    public string yes;
    [XmlElement("no")]
    public string no;
    [XmlElement("thanks")]
    public string thanks;
    [XmlElement("back")]
    public string back;

    //main screen
    [XmlElement("options")]
    public string options;
    [XmlElement("play")]
    public string play;
    [XmlElement("developer")]
    public string developer;

    //scenes screen
    [XmlElement("main_screen")]
    public string main_screen;
    [XmlElement("linear")]
    public string linear;
    [XmlElement("power")]
    public string power;
    [XmlElement("root")]
    public string root;
    [XmlElement("logarithm")]
    public string logarithm;
    [XmlElement("exponental")]
    public string exponental;
    [XmlElement("trigonometric")]
    public string trigonometric;
    [XmlElement("polinomial")]
    public string polinomial;
    [XmlElement("hyperbolic")]
    public string hyperbolic;
    [XmlElement("mixed")]
    public string mixed;
    [XmlElement("special")]
    public string special;

    //game screen
    [XmlElement("reset")]
    public string reset;
    [XmlElement("run")]
    public string run;
    [XmlElement("completed")]
    public string completed;
    [XmlElement("stars")]
    public string stars;
    [XmlElement("buy_stars_prompt")]
    public string buy_stars_prompt;
    [XmlElement("tap_to_continue")]
    public string tap_to_continue;
    [XmlElement("tip1")]
    public string tip1;
    [XmlElement("tip2")]
    public string tip2;
    [XmlElement("tip3")]
    public string tip3;
    [XmlElement("tip4")]
    public string tip4;

    //shop
    [XmlElement("choose_ball")]
    public string choose_ball;

    //options
    [XmlElement("delete_progress")]
    public string delete_progress;
    [XmlElement("name_1")]
    public string name_1;
    [XmlElement("position_1")]
    public string position_1;
    [XmlElement("name_2")]
    public string name_2;
    [XmlElement("position_2")]
    public string position_2;
    [XmlElement("name_3")]
    public string name_3;
    [XmlElement("position_3")]
    public string position_3;

    //star shop
    [XmlElement("add")]
    public string add;
}
