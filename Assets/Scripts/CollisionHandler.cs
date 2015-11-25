using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {

        Saver.levelComplete();

        CompletedScreen.getInstanse().SetActive(true);
    }
}
