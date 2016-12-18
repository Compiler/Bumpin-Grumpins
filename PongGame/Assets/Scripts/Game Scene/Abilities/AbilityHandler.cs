using UnityEngine;
using System.Collections;

public class AbilityHandler : MonoBehaviour {


    float elapsedTime = 0;
    /*
     * Where you left off:
     * Create reference using object and script thing and then
     * set boolean for active to on then off... goodluck.. was silicon good? 
     */
    // Use this for initialization

    private int[] list;
    private int abilityNum;

    private PaddleEnlarge paddleScript;
    private SpeedBall ballScript;
    private GameObject paddle, ball;

    void Start () {
        paddle = GameObject.Find("ExpandPaddle");
        ball = GameObject.Find("Speed");


        paddleScript = paddle.GetComponent<PaddleEnlarge>();
        ballScript = ball.GetComponent<SpeedBall>();
	    
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 5) {
            abilityNum = Random.Range(0, 5);
            elapsedTime = 0;

        }

        //Paddle enlargment
        if (abilityNum == 1)
        {
            enlargePaddle();
        }
        else if (abilityNum == 2)
        {
            speedBall();
        }
        else if (abilityNum == 3) {
            tripleBall();
        }

	}


    public void enlargePaddle() {

       
        paddleScript.startAvailability();
        abilityNum = -1;
    }

    public void speedBall() {

        ballScript.startSpeed();
        abilityNum = -1;

    }

    public void tripleBall() {

        GameObject.Find("TrippleBall").GetComponent<TripleBall>().setAvail(true);
        abilityNum = -1;
    }
}
