﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour

{
    void OnCollisionEnter2D(Collision2D col)
    {
        var x = col.transform.position.x - gameObject.transform.position.x;
        var y = col.transform.position.y - gameObject.transform.position.y;

        Vector2 localBallPosition = new Vector2(x * Mathf.Cos(gameObject.transform.eulerAngles.z / 180 * Mathf.PI) +
                                                y * Mathf.Sin(gameObject.transform.eulerAngles.z / 180 * Mathf.PI),
                                                -x * Mathf.Sin(gameObject.transform.eulerAngles.z / 180 * Mathf.PI) +
                                                y * Mathf.Cos(gameObject.transform.eulerAngles.z / 180 * Mathf.PI));

        localBallPosition.y = localBallPosition.y - gameObject.GetComponent<Collider2D>().offset.y * 
                                gameObject.transform.parent.transform.localScale.y;

        //Debug.Log("local position " + localBallPosition);

        if (localBallPosition.y > 0)
        {
            //print("Level complete");

            var completed = CompletedScreen.getInstanse();

            completed.SetActive(true);

            if (!Saver.isLevelComplete(ScenesParameters.CurrentLevel))
            {
                Shop.AddStar(Shop.levelAward);
                Saver.levelComplete();
                var gotStars = completed.transform.FindChild("Canvas_Completed").FindChild(
                                "Image_Completed").FindChild("GotStars").gameObject;

                gotStars.SetActive(true);
                gotStars.transform.FindChild("StarCountText").GetComponent<Text>().text = 
                                    "+ " + Shop.levelAward + " stars";
            }
        }
    }
}
