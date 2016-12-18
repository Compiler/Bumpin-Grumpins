using UnityEngine;
using System.Collections;

public class SpeedBall : AbilitySuper {

    // Use this for initialization

    private GameObject ball;
    private Ball ballScript;
    private float speed = 10;
    private bool gotSpeed;
    private Vector3 origSpeed;
	void Start () {

        ball = GameObject.Find("ball");
        
        ballScript = ball.GetComponent<Ball>();
        
        
        initTimed(5);
    }
	
	// Update is called once per frame
	protected override void Update () {
        if (!gotSpeed && ballScript.getVelocity().x != 0) {
            origSpeed = ballScript.getVelocity();
            gotSpeed = true;

        }
        base.Update();

        if (Input.GetKey(KeyCode.G))
            abilityStarted = true;
        if (Input.GetKey(KeyCode.F))
          abilityAliveTime = 100;


        checkForStart();
        checkForEnd();

    }
    bool assigner;
    public void checkForStart() {

        if (abilityStarted)
        {
            if (assigner)
            {
                ballScript.setVelocity(ballScript.getVelocity().x * 2, ballScript.getVelocity().y * 2);
                assigner = false;
            }
        }
        else
            assigner = true;
    }


    void OnTriggerEnter(Collider col)
    {
        base.checkCollision(col);

    }

    public void startSpeed() {
        base.abilityAvailable = true;
    }
    private Vector3 grabSpeed = new Vector3();
    public void checkForEnd()
    {

        if (base.abilityDone()) {
            abilityStarted = false;

            ballScript.resetSpeedToOriginal();
        }
    }

    public bool getAvail() {
        return base.abilityAvailable;
    }

    
}
