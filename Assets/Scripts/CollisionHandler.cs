using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        CompletedScreen.getInstanse().SetActive(true);
    }
}
