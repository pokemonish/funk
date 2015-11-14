﻿using UnityEngine;
using UnityEngine.UI;
using ExpressionParser;
using System.Collections.Generic;
using System;

public class DrawGraph : MonoBehaviour {

    private GameObject inputFieldGo;
    private GameObject setUp;
    private InputField inputFieldCo;

    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;

    private ExpressionParser.ExpressionParser parser;
    private Camera cam;
    private float minSide, from, to, step, standartLineThickness;
    private Transform DotPrefab;
    
    List<BoxCollider2D> graphDots = new List<BoxCollider2D>();


    // Use this for initialization
    void Start () {
        inputFieldGo = GameObject.Find("InputField");
        inputFieldCo = inputFieldGo.GetComponent<InputField>();

        parser = new ExpressionParser.ExpressionParser();
        minSide = (Screen.width < Screen.height ? Screen.width : Screen.height) * 2f;
        cam = GameObject.Find("Camera").GetComponent<Camera>();

        var scaledSide = cam.ScreenToWorldPoint(new Vector3(minSide / 7200, 0f, 0f)).x;

        standartLineThickness = scaledSide < 0.1f ? 0.1f : scaledSide;
        step = standartLineThickness * 2;

        from = cam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - step;
        to = cam.ScreenToWorldPoint(new Vector3(minSide / 2, 0f, 0f)).x + step;
    }
	
	// Update is called once per frame
	void Update() {

        BoxCollider2D colliderPrev = null;

        foreach (BoxCollider2D collider in graphDots)
        {
            if (colliderPrev != null)
            {
                Debug.DrawLine(colliderPrev.transform.position, collider.transform.position);
            }
            colliderPrev = collider;
        }
    }

    private bool goodNumbers(params double[] nums)
    {
        foreach(double n in nums) {
            if (double.IsInfinity(n) || double.IsNaN(n))
                return false;
        }
        return true;
    }

    private void buildSegment(double x, double y, double prevX, double prevY)
    {
        var newDotPosition = new Vector2((float)x, (float)y);
        var lastDotPosition = new Vector2((float)prevX, (float)prevY);

        //Transform dot = (Transform)Instantiate(DotPrefab, newDotPosition, Quaternion.identity);

        var colliderKeeper = new GameObject("collider");
        colliderKeeper.transform.position = Vector2.Lerp(newDotPosition, lastDotPosition, 0.5f);
        var diff = lastDotPosition - newDotPosition;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        colliderKeeper.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        Debug.DrawLine(lastDotPosition, newDotPosition);
        BoxCollider2D bc = colliderKeeper.AddComponent<BoxCollider2D>();
        bc.size = new Vector2(standartLineThickness, Vector2.Distance(lastDotPosition, newDotPosition));
        graphDots.Add(bc);
    }

    private void BuildPlot(ExpressionDelegate fun)
    {      

        foreach (BoxCollider2D dot in graphDots)
        {
            Destroy(dot);
        }
        graphDots.Clear();

        double w = Math.Abs(to - from);
        double sw = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
        double xPrev = from + sw - 10 * w / 20;

        if (fun != null)
        {
            double yPrev = fun(-10) / 20 * w;

            for (double x = -10 + step; x < 10; x += step)
            {
                double ty = fun(x) / 20 * w;
                double tx = from + sw  + x * w / 20;
                if (goodNumbers(tx, ty, xPrev, yPrev))
                    buildSegment(tx, ty, xPrev, yPrev);
                xPrev = tx;
                yPrev = ty;
            }
        }
        else
        {
            for (double x = -10 + step; x < 10; x += step)
            {
                double tx = from + sw + x * w / 20;
                if (goodNumbers(tx, xPrev))
                    buildSegment(tx, 0, xPrev, 0);
                xPrev = tx;
            }
        }       
    }

    public void GetText()
    {
        try
        {
            Expression exp = parser.EvaluateExpression(inputFieldCo.text);
            ExpressionDelegate fun = exp.ToDelegate("x");
            BuildPlot(fun);
        }
        catch (KeyNotFoundException e)
        {
            Expression exp = parser.EvaluateExpression(inputFieldCo.text);
            ExpressionDelegate fun = exp.ToDelegate();
            BuildPlot(fun);
        }
        catch (ExpressionParser.ExpressionParser.ParseException ex)
        {
            BuildPlot(null);
        }
    }
}