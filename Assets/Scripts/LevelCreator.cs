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

    public GameObject Completed;

    private GameObject ballClone;
    private GameObject basketClone;
    private GameObject triangleClone;

    private int levelsNumber;

    // Use this for initialization
    void Start () {

        //ScenesParameters.CurrentLevel = 1;
        //ScenesParameters.Section = "linear";

        var configPass = Path.Combine(Directory.GetCurrentDirectory(),
                                    ScenesParameters.LevelsDirectory + '/'
                                    + ScenesParameters.Section +
                                    '/' + "config");

        /*System.IO.StreamReader file =
            new System.IO.StreamReader(configPass);

        string line;

        while ((line = file.ReadLine()) != null)
        {
            Debug.Log(line);
            ScenesParameters.LevelsNumber = Int32.Parse(line);
        }

        file.Close();*/

        createLevelFromXml(ScenesParameters.LevelName + ScenesParameters.CurrentLevel);
    }

    private void createLevelFromXml(string filename)
    {
        var parser = new XMLParser();

        var level = (Level)parser.parse(filename);

        if (level.ball != null)
        {
            ballClone = (GameObject)Instantiate(MyBall, new Vector3(level.ball.x, level.ball.y, 0f), Quaternion.Euler(0, 0, 0));
            xDef = level.ball.x;
            yDef = level.ball.y;
        }

        if (level.basket != null)
        {
            var basketPosition = new Vector3(level.basket.x, level.basket.x, 0f);
            basketClone = (GameObject)Instantiate(MyBasket, basketPosition, Quaternion.AngleAxis(level.basket.angle, Vector3.forward));
        }

        if (level.ObsticleTriangle != null)
        {
            MyTriangle.transform.position = new Vector2(level.ObsticleTriangle.x, level.ObsticleTriangle.y);
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
