using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class LevelCreator : MonoBehaviour {

    public GameObject MyBall;
    public GameObject MyBasket;
    public GameObject MyTriangle;

    public float xDef;
    public float yDef;

    public GameObject devInterface;

    private GameObject ballClone;
    private GameObject basketClone;
    private GameObject triangleClone;

    private int levelsNumber;

    // Use this for initialization
    void Start () {
        if (!ScenesParameters.Devmode)
        {
            createLevelFromXml(ScenesParameters.LevelName + ScenesParameters.CurrentLevel);
        } else
        {
            devInterface = Instantiate(devInterface);
            devInterface.SetActive(true);
            ScenesParameters.Section = "linear";
            TextAsset text = Resources.Load(ScenesParameters.LevelsDirectory + '/'
                                + ScenesParameters.Section + '/' + "config") as TextAsset;

            ScenesParameters.LevelsNumber = Int32.Parse(text.text);
        }
    }

    private void createLevelFromXml(string filename)
    {
        var parser = new XMLParser();

        var level = (Level)parser.parse(filename);

        Debug.Log(Screen.width);
        Debug.Log(Screen.height);

        if (level.ball != null)
        {
            var ballPosition = new Vector3(level.ball.x,
                                                   level.ball.y, 0f);
            Debug.Log(ballPosition);
            ballClone = (GameObject)Instantiate(MyBall, ballPosition, Quaternion.Euler(0, 0, 0));
            xDef = ballPosition.x;
            yDef = ballPosition.y;
        }

        if (level.basket != null)
        {
            var basketPosition = new Vector3(level.basket.x, level.basket.y, 0f);
            Debug.Log(basketPosition);
            basketClone = (GameObject)Instantiate(MyBasket, basketPosition, 
                        Quaternion.AngleAxis(level.basket.angle, Vector3.forward));
        }

        if (level.ObsticleTriangle != null)
        {
            var brickPosition = 
                new Vector2(level.ObsticleTriangle.x, level.ObsticleTriangle.y);

            triangleClone = (GameObject)Instantiate(MyTriangle, brickPosition,
                            Quaternion.AngleAxis(level.ObsticleTriangle.angle, Vector3.forward));
        }
    }

    public void setPosition()
    {
        ballClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        ballClone.GetComponent<Rigidbody2D>().angularVelocity = 0;
        ballClone.GetComponent<Transform>().position = new Vector3(xDef, yDef, 0f);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
