using UnityEngine;
using System.Collections;

public class DeleteProgress : MonoBehaviour {
	public void Delete(){
		PlayerPrefs.DeleteAll ();
        BallParametrs.ballSprite = Resources.Load<Sprite>("BallTexture/" + "Default");
    }
}
