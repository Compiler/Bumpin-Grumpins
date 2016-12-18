using UnityEngine;
using System.Collections;

public class BallFlipper : MonoBehaviour {

    private SpriteRenderer renderer;
    private Transform ball;
	void Start () {

        renderer = GetComponent<SpriteRenderer>();
        ball = GetComponentInParent<Transform>();
	}

    float tmp1, tmp2;
	void Update () {
        tmp1 = ball.position.x + 5;

        if (tmp1 < tmp2)
            renderer.flipX = true;

        if (tmp2 < tmp1)
            renderer.flipX = false;
        


        tmp2 = ball.position.x + 5;
        


    }
}
