using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class SectionsUp : MonoBehaviour {

	public void SelectSection(string sectionName){
		
		ScenesParameters.Section = sectionName;
		TextAsset text = Resources.Load(ScenesParameters.LevelsDirectory + '/'
			+ ScenesParameters.Section + '/' + "config") as TextAsset;

		ScenesParameters.LevelsNumber = Int32.Parse(text.text);
		if (!ScenesParameters.Devmode)
		{
			Application.LoadLevel(2);
		} else
		{
			Application.LoadLevel(3);
		}
	}
}
