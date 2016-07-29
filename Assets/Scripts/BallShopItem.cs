using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallShopItem : MonoBehaviour {

    public bool isBought;
    public bool Select;
    public string Name;
    public Image image;
	
	void Update () {
       
        isBought = Name == "Default" || PlayerPrefs.GetString(Name) == "Buyed";
        Select = BallParametrs.ballSprite == image.sprite;
        image.color = Select ? Color.white : Color.gray;
        image.sprite = isBought ? Resources.Load<Sprite>("BallTexture/" + Name) : Resources.Load<Sprite>("BallTexture/" + "closeBall");
	}
    public void Click() {
        if (isBought)
        {
            BallParametrs.ballSprite = image.sprite;
        }
        else {
            print(Shop.Buy(Name));
        }
    }
}
