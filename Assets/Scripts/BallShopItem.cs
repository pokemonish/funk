using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallShopItem : MonoBehaviour {
    public string Name;
    public Image image;

    public void Start()
    {  
        image.sprite = isBought() ? Resources.Load<Sprite>("BallTexture/" + Name) : Resources.Load<Sprite>("BallTexture/" + "closeBall");
    }

	void Update () {
        image.color = isSelected() ? Color.white : Color.gray;
    }

    public void Click() {
        if (isBought())
        {
            BallParametrs.ballSprite = image.sprite;
        }
        else {
            if (Shop.Buy(Name))
            {
                image.sprite = Resources.Load<Sprite>("BallTexture/" + Name);           
                BallParametrs.ballSprite = image.sprite;
            }
        }
    }

    private bool isBought()
    {
        return Name == "Default" || PlayerPrefs.GetString(Name) == "Buyed";
    }

    private bool isSelected()
    {
        return BallParametrs.ballSprite == image.sprite;
    }
}
