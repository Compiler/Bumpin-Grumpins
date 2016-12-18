using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	public float ballVelocity = .010f;

	Rigidbody rb;
	bool isPlay;
	int randInt;
	public Vector3 velocity, position; 
	float elapsed = 0;
    
    private bool onLeft, offScreen;
    public Vector3 startPos = new Vector3(0, 0, 0);
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		randInt = Random.Range(1,3);
		velocity = new Vector3 (ballVelocity, ballVelocity, 0);
        position = new Vector3();

	}
    private float startTimer = 0, transTime = 0;
    bool transComplete;
	void Update()
	{
        controlSpeeds();
        ballVelocity = 5f * Time.deltaTime;
        if (rb.position.x < 0)
            onLeft = true;
        else
            onLeft = false;

		rb.drag = 0;
        checkForPause();
		

        
		rb.maxDepenetrationVelocity = ballVelocity;
        startTimer = Time.timeSinceLevelLoad;
        
		if (startTimer > 6 && isPlay == false)
		{
			//transform.parent = null;
			isPlay = true;
			rb.isKinematic = false;
            
			if (randInt == 1)
            {
                
                velocity.x = ballVelocity;
                velocity.y = ballVelocity;
                

            }
			if (randInt == 2)
			{
                velocity.x = -ballVelocity;
                velocity.y = -ballVelocity;


            }
		}

        position.x += velocity.x;
        position.y += velocity.y;
        transform.position = position;
      
	}
    private Vector2 tmpVel;
    private bool wait;
    public void checkForPause()
    {
        if (GameObject.Find("Pause").GetComponent<Pause>().isPaused())
        {
            if (wait)
            {
                tmpVel = velocity;
                wait = false;
            }
            velocity.x = 0;
            velocity.y = 0;
        }
        else {
            if (wait == false) {
                velocity = tmpVel;
            }
            wait = true;

        }
    }

    public void controlSpeeds() {

        if (Mathf.Abs(velocity.x) != Mathf.Abs(velocity.y)) {
            Debug.Log("not equal: (" + velocity.x + ", " + velocity.y + ")");
        }
    }
   

    public void setIsOffScreen(bool cond) {
        this.offScreen = cond;
    }

    public bool isOffScreen() {
        return this.offScreen;
    }

    public void setVelocity(float x, float y)
    {
        velocity.x = x;
        velocity.y = y;

    }

    
    public void multiplyVelocity(float speed) {
        velocity.x *= speed;
        velocity.y *= speed;
    }

    public void bounce() {
        velocity.x = -velocity.x;
        velocity.y = -velocity.y;
        
    }

    public void bounceX() {
        velocity.x = -velocity.x;
    }

    public void bounceY()
    {
        velocity.y = -velocity.y;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("wall"))
        {

            bounceY();

        }

        if (col.tag.Equals("paddle"))
        {

            bounceX();

        }

    }

    public Vector2 getVelocity() { return this.velocity; }
    public void resetSpeedToOriginal() {
        if (velocity.x < 0)
        {
            velocity.x = -ballVelocity;
        }
        else
            velocity.x = ballVelocity;


        if (velocity.y < 0)
        {
            velocity.y = -ballVelocity;
        }
        else
            velocity.y = ballVelocity;
    }
}