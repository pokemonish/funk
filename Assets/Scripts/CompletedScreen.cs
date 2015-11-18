using UnityEngine;
using System.Collections;

public class CompletedScreen : MonoBehaviour {

    public GameObject CompletedPrefab;
    public static GameObject Completed;

    void Start()
    {
        Completed = CompletedPrefab;
        Completed = Instantiate(Completed);

    }

    public static GameObject getInstanse() {
        return Completed;
    }
}
