using UnityEngine;
using UnityEngine.UI;
using ExpressionParser;
using System.Collections.Generic;
using System;

public class DrawGraph : MonoBehaviour
{
    public Material material;
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
    List<LineRenderer> lines = new List<LineRenderer>();


    // Use this for initialization
    void Start()
    {
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

    private LineRenderer createLine()
    {
        LineRenderer line;

        line = new GameObject("Line").AddComponent<LineRenderer>();

        line.SetWidth(0.06f, 0.06f);
       
        line.material = this.material;

        line.material.SetColor("_Color", new Color(0.8824f, 0.1843f, 0.0413f));

        line.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        line.SetColors(new Color(0.8824f, 0.1843f, 0.0413f), new Color(0.8824f, 0.1843f, 0.0413f));

        line.SetVertexCount(2);

        return line;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private bool goodNumbers(params double[] nums)
    {
        foreach (double n in nums)
        {
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

        var line = createLine();

        line.SetPosition(0, lastDotPosition);
        line.SetPosition(1, newDotPosition);

        lines.Add(line);

        colliderKeeper.transform.position = Vector2.Lerp(newDotPosition, lastDotPosition, 0.5f);
        var diff = lastDotPosition - newDotPosition;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        colliderKeeper.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        BoxCollider2D bc = colliderKeeper.AddComponent<BoxCollider2D>();
        bc.size = new Vector2(standartLineThickness, Vector2.Distance(lastDotPosition, newDotPosition));

        graphDots.Add(bc);
    }

    private void BuildPlot(ExpressionDelegate fun)
    {

        deleteLines();

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
                double tx = from + sw + x * w / 20;
                if (Math.Abs(ty) < w / 2 && Math.Abs(yPrev) < w / 2 && goodNumbers(tx, ty, xPrev, yPrev))
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

    private void deleteLines()
    {
        foreach (LineRenderer line in lines)
        {
            Destroy(line);
        }

        lines.Clear();
    }

    public void GetText()
    {

        if (ScenesParameters.isValid) {
            try
            {
                string rawExp = inputFieldCo.text.Replace("<color=#E12F0BFF>", "").Replace("</color>", "");
                Expression exp = parser.EvaluateExpression(rawExp);
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
}