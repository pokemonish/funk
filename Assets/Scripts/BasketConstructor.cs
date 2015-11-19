using UnityEngine;
using System.Collections;
using System;

public class BasketConstructor : MonoBehaviour {

    public Camera cam;

    public GameObject bottom;
    public GameObject leftWall;
    public GameObject rightWall;

    private const float standartWallThickness = 0.15f;
    private const double sidesAngle = 0.262;

    private const float basketScale = 0.15f;

    // Use this for initialization
    void Start () {
        var renderer = (SpriteRenderer)gameObject.GetComponent<SpriteRenderer>();

        var currentScale = renderer.bounds.size.x / cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;

        renderer.transform.localScale = new Vector2(basketScale / currentScale, basketScale / currentScale);

        var backetSize = new Vector2 (renderer.sprite.bounds.size.x, 
                                        renderer.sprite.bounds.size.y);
        
        var bottomCollider = (BoxCollider2D)bottom.GetComponent<BoxCollider2D>();
        bottomCollider.size = new Vector2(backetSize.x * 0.7f, standartWallThickness);
        bottomCollider.offset = new Vector2(0f, (backetSize.y / 2 - standartWallThickness) *-1);

        var leftCollider = (BoxCollider2D)leftWall.GetComponent<BoxCollider2D>();
        var rightCollider = (BoxCollider2D)rightWall.GetComponent<BoxCollider2D>();

        leftCollider.size = new Vector2(standartWallThickness, backetSize.y * 0.9f);
        rightCollider.size = leftCollider.size;

        var halfMiddleLine = (backetSize.x + bottomCollider.size.x) / 4;

        leftCollider.offset = new Vector2(-halfMiddleLine, standartWallThickness);
        rightCollider.offset = new Vector2(halfMiddleLine, standartWallThickness);

        leftWall.transform.Rotate(new Vector3(0f, 0f, (float)(sidesAngle / 2 / Math.PI * 180)));
        rightWall.transform.Rotate(new Vector3(0f, 0f, -(float)(sidesAngle / 2 / Math.PI * 180)));
    }

	// Update is called once per frame
	void Update () {
	    
	}
}
