using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System;

[XmlRoot("Level")]
public class Level {
    
    public Level() {}

    public Level(GameObject _ball, GameObject _basket, GameObject _obsticle)
    {
        Debug.Log("Scale is " + _ball.transform.localScale.x);

        ball = new Ball(_ball.transform.position.x,
                        _ball.transform.position.y,
                        _ball.transform.localScale.x,
                        null);

        basket = new Basket(_basket.transform.position.x,
                            _basket.transform.position.y,
                            _basket.transform.localScale.x,
                            _basket.transform.eulerAngles.z);

        if (_obsticle != null)
        {
            ObsticleBrick = new ObsticleBrick(_obsticle.transform.position.x,
                                                _obsticle.transform.position.y,
                                                _obsticle.transform.localScale.x,
                                                _obsticle.transform.eulerAngles.z);
        }
    }

    public Level(Ball _ball, Basket _basket, ObsticleBrick _ObsticleTriangle) {
        ball = _ball;
        basket = _basket;
        ObsticleBrick = _ObsticleTriangle;
    }

    [XmlElement("Ball")]
    public Ball ball { get; set; }

    [XmlElement("Basket")]
    public Basket basket { get; set; }

    [XmlElement("TriangleObsticle")]
    public ObsticleBrick ObsticleBrick { get; set; }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}


public class BasicLevelItem
{
    public BasicLevelItem() {}

    public BasicLevelItem(float x, float y, float scale)
    {
        this.x = x;
        this.y = y;
        this.scale = scale;
    }

    
    public float x { get; set; }
    
    public float y { get; set; }

    public float scale { get; set; }
}

public class LevelItemWithAngle : BasicLevelItem
{
    public LevelItemWithAngle() {}

    public LevelItemWithAngle(float x, float y, float scale, float angle) :
        base(x, y, scale)
    {
        this.angle = angle;
    }

    
    public float angle { get; set; }
}

public class Basket : LevelItemWithAngle
{
    Basket() {}

    public Basket(float x, float y, float scale, float angle) :
        base(x, y, scale, angle) { }
}

public class Ball : BasicLevelItem
{
    public Ball() {}

    public Ball(float x, float y, float scale, string _image) : base(x, y, scale) {
        image = _image;
    }

    
    public string image { get; set; }
}

public class ObsticleBrick : LevelItemWithAngle
{
    public ObsticleBrick() {}

    public ObsticleBrick(float x, float y, float scale, float angle) :
        base(x, y, scale, angle) { }
}
