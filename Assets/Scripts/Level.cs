using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System;

[XmlRoot("Level")]
public class Level {
    
    public Level() {}

    public Level(Ball _ball, Basket _basket, ObsticleTriangle _ObsticleTriangle) {
        ball = _ball;
        basket = _basket;
        ObsticleTriangle = _ObsticleTriangle;
    }

    [XmlElement("Ball")]
    public Ball ball { get; set; }

    [XmlElement("Basket")]
    public Basket basket { get; set; }

    [XmlElement("TriangleObsticle")]
    public ObsticleTriangle ObsticleTriangle { get; set; }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}


public class BasicLevelItem
{
    public BasicLevelItem() {}

    public BasicLevelItem(float _x, float _y)
    {
        x = _x;
        y = _y;
    }

    
    public float x { get; set; }
    
    public float y { get; set; }
}

public class LevelItemWithAngle : BasicLevelItem
{
    public LevelItemWithAngle() {}

    public LevelItemWithAngle(float _x, float _y, float _angle) :
        base(_x, _y)
    {
        angle = _angle;
    }

    
    public float angle { get; set; }
}

public class Basket : LevelItemWithAngle
{
    Basket() {}

    public Basket(float _x, float _y, float _angle) :
        base(_x, _y, _angle) { }
}

public class Ball : BasicLevelItem
{
    public Ball() {}

    public Ball(float _x, float _y, string _image) : base(_x, _y) {
        image = _image;
    }

    
    public string image { get; set; }
}

public class ObsticleTriangle : LevelItemWithAngle
{
    public ObsticleTriangle() {}

    public ObsticleTriangle(float _x, float _y, float _angle) :
        base(_x, _y, _angle) { }
}
