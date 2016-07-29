using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        var completed = CompletedScreen.getInstanse();

        completed.SetActive(true);

        if (!Saver.isLevelComplete(ScenesParameters.CurrentLevel))
        {
            Shop.AddStar(Shop.levelAward);
            Saver.levelComplete();
            var gotStars = completed.transform.FindChild("Canvas_Completed").FindChild("Image_Completed").FindChild("GotStars").gameObject;

            gotStars.SetActive(true);
            gotStars.transform.FindChild("StarCountText").GetComponent<Text>().text = "+ " + Shop.levelAward + " stars";
        }
    }
}
