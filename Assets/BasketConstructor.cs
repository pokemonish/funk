using UnityEngine;
using System.Collections;
using System;

public class BasketConstructor : MonoBehaviour {

    public Camera cam = new Camera();

    public GameObject bottom;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    private static float standartWallThickness = 0.15f;
    private static double sidesAngle = 0.262;

    // Use this for initialization
    void Start () {
        var renderer = (Renderer)gameObject.GetComponent<Renderer>();
        
        var backetSize = new Vector3 (renderer.bounds.size.x * 2, renderer.bounds.size.y * 2);
        
        var bottomCollider = (BoxCollider2D)bottom.GetComponent<BoxCollider2D>();
        bottomCollider.size = new Vector2(backetSize.x * 0.85f, standartWallThickness);
        bottomCollider.offset = new Vector2(0f, backetSize.y / 2 *-1);
        Debug.Log(bottomCollider.size.x);

        leftWall.size = new Vector2(standartWallThickness, backetSize.y);
        rightWall.size = leftWall.size;

        var halfMiddleLine = (backetSize.x + bottomCollider.size.x) / 4;

        leftWall.offset = new Vector2(-halfMiddleLine, standartWallThickness);
        rightWall.offset = new Vector2(halfMiddleLine, standartWallThickness);

        leftWall.transform.rotation = Quaternion.Euler(0f, 0f, (float)(sidesAngle / 2 / Math.PI * 180));
        rightWall.transform.rotation = Quaternion.Euler(0f, 0f, -(float)(sidesAngle / 2 / Math.PI * 180));
    }

	// Update is called once per frame
	void Update () {
	    
	}
}
