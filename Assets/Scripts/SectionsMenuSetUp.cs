using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class SectionsMenuSetUp : MonoBehaviour {

    //hardcode hardcode hardcode
    private string[] sections = { "linear", "power", "root" };

    public Texture linearTexture;
    public Texture powerTexture;
    public Texture rootTexture;

    private Dictionary<string, Texture> icons = new Dictionary<string, Texture>();

    // Use this for initialization
    void Start () {
        icons["linear"] = linearTexture;
        icons["power"] = powerTexture;
        icons["root"] = rootTexture;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        var buttonSize = (new Vector3(Screen.width / 3f, Screen.width / 3f, 0f));
        for (int i = 0; i < sections.Length; ++i)
        {

            if (GUI.Button(new Rect(Screen.width  * 0.25f - buttonSize.x / 2 + Screen.width / 2 * (1 - (i+1) % 2),
                Screen.width * 0.25f - buttonSize.x / 2 + buttonSize.y * 1.2f * (float)Math.Round((double)i / 2), 
                buttonSize.x, buttonSize.y), icons[sections[i]]))
            {
                ScenesParameters.Section = sections[i];

                TextAsset text = Resources.Load(ScenesParameters.LevelsDirectory + '/'
                                + ScenesParameters.Section + '/' + "config") as TextAsset;
                Debug.Log(text);
                Debug.Log(ScenesParameters.LevelsDirectory + '/'
                                + ScenesParameters.Section + '/' + "config");

                ScenesParameters.LevelsNumber = Int32.Parse(text.text);
                /*var configPass = Path.Combine(Directory.GetCurrentDirectory(),
                                            ScenesParameters.LevelsDirectory + Path.DirectorySeparatorChar
                                            + ScenesParameters.Section +
                                            Path.DirectorySeparatorChar + "config");

                System.IO.StreamReader file =
                    new System.IO.StreamReader(configPass);

                string line;

                while ((line = file.ReadLine()) != null)
                {
                    Debug.Log(line);
                    ScenesParameters.LevelsNumber = Int32.Parse(line);
                }

                file.Close();*/

                Application.LoadLevel(2);
            }
        }
    }
}
