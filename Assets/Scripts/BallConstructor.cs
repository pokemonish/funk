using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallConstructor : MonoBehaviour {

    public Camera cam;
	private SpriteRenderer spriteBall;
    public CircleCollider2D ball;

    public Image defaultImage;

    // Use this for initialization
    void Start () {
		spriteBall = GetComponent<SpriteRenderer>();
        if (BallParametrs.ballSprite == null)
        {
            BallParametrs.ballSprite = defaultImage.sprite;
        }

        spriteBall.sprite = BallParametrs.ballSprite;
    }
	

}
