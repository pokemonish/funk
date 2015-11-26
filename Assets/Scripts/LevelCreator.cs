using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class LevelCreator : MonoBehaviour {

    public GameObject MyBall;
    public GameObject MyBasket;
    public GameObject MyTriangle;
    public GameObject ErrorText;

    public float xDef;
    public float yDef;

    public GameObject devInterface;

    private GameObject ballClone;
    private GameObject basketClone;
    private GameObject brickClone;
    private string funk;

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

        if (level.ball != null)
        {
            var ballPosition = new Vector3(level.ball.x, level.ball.y, 0f);
            
            ballClone = (GameObject)Instantiate(MyBall, ballPosition, Quaternion.Euler(0, 0, 0));

            Debug.Log("Localscale is " + ballClone.transform.localScale);

            ballClone.transform.localScale = new Vector3(level.ball.scale, level.ball.scale, 1f);

            Debug.Log("Scalelele " + ballClone.GetComponent<Transform>().localScale);
            Debug.Log("scale is " + level.ball.scale);
            Debug.Log("Localscale is " + ballClone.transform.localScale);
            Debug.Log("Lossyscale is " + ballClone.transform.lossyScale);


            xDef = ballPosition.x;
            yDef = ballPosition.y;
        }

        if (level.basket != null)
        {
            var basketPosition = new Vector3(level.basket.x, level.basket.y, 0f);
            
            basketClone = (GameObject)Instantiate(MyBasket, basketPosition, 
                        Quaternion.AngleAxis(level.basket.angle, Vector3.forward));

            basketClone.transform.localScale = new Vector3(level.basket.scale, level.basket.scale, 1f);
        }

        if (level.ObsticleBrick != null)
        {
            var brickPosition = 
                new Vector2(level.ObsticleBrick.x, level.ObsticleBrick.y);

            brickClone = (GameObject)Instantiate(MyTriangle, brickPosition,
                            Quaternion.AngleAxis(level.ObsticleBrick.angle, Vector3.forward));

            brickClone.transform.localScale = new Vector3(level.ObsticleBrick.scale, level.ObsticleBrick.scale, 1f);
        }

        funk = level.Funk;

        var inputFieldGo = GameObject.Find("InputField");
        var inputFieldCo = inputFieldGo.GetComponent<InputField>();

        //inputFieldCo.keyboardType = TouchScreenKeyboardType.NumbersAndPunctuation;
        //inputFieldCo.text = "<color = red>" + level.Funk + "</color>";

        //inputFieldCo.text = "<size=30><color=red>" + level.Funk + "</color></size>";

        inputFieldCo.text = level.Funk;

        inputFieldCo.onValueChange.AddListener(delegate { ValueChangeCheck(); });

        ScenesParameters.isValid = true;
    }

    public void resetField()
    {
        var inputFieldGo = GameObject.Find("InputField");
        var inputFieldCo = inputFieldGo.GetComponent<InputField>();

        //inputFieldCo.text = "<color = red>" + level.Funk + "</color>";

        //inputFieldCo.text = "<size=30><color=red>" + level.Funk + "</color></size>";

        inputFieldCo.text = funk;

    }

    public void ValueChangeCheck()
    {
        var inputFieldGo = GameObject.Find("InputField");
        var inputFieldCo = inputFieldGo.GetComponent<InputField>();

        int index = inputFieldCo.text.IndexOf(funk);

        if (index == -1)
        {
            ScenesParameters.isValid = false;
            ErrorText.SetActive(true);
        } else
        {
            ScenesParameters.isValid = true;
            ErrorText.SetActive(false);
        }
    }

public void setPosition()
    {
        if (ScenesParameters.isValid) {
            ballClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            ballClone.GetComponent<Rigidbody2D>().angularVelocity = 0;
            ballClone.GetComponent<Transform>().position = new Vector3(xDef, yDef, 0f);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
