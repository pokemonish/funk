using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    public GameObject Completed;
    public Canvas Interface;

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        Completed.SetActive(true);
        GUI.enabled = false;
    }
}
