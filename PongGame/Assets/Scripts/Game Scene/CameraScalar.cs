using UnityEngine;
using System.Collections;

public class CameraScalar : MonoBehaviour
{

    private Vector2 cameraDim;
    
    void Start()
    {
       

        GameObject paddle = GameObject.Find("paddle");
        Paddle script = paddle.GetComponent<Paddle>();
        script.setInitialPosition();
        

        GameObject paddleRight = GameObject.Find("paddle right");
        PaddleRight rightScript = paddleRight.GetComponent<PaddleRight>();
        rightScript.setInitialPosition();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
