using UnityEngine;
using System.Collections;

public class DeveloperTools : MonoBehaviour {

    private bool ballIsFreezed = false;

	public void FreezeBall()
    {
        var balls = GameObject.FindGameObjectsWithTag("Ball");

        if (balls[0] != null)
        {
            var ball = balls[0];

            var rigidbody = ball.GetComponent<Rigidbody2D>();

            if (ballIsFreezed)
            {
                rigidbody.constraints = RigidbodyConstraints2D.None;
            }
            else
            {
                rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            }

            ballIsFreezed = !ballIsFreezed;
        }
    }
}
