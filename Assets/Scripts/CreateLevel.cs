using UnityEngine;
using System.Collections;

public class CreateLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void create()
    {
        var parser = new XMLParser();
        parser.makeLevelFromCurrentState();
    }
}
