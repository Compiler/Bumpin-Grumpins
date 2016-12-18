using UnityEngine;
using System.Collections;

public class TripleBall : AbilitySuper {

    
    private int amountOfBalls = 3;
    private int ballCount = 3;
    private Ball[] ballArray;
    private float elapsedTime = 0;
    private int touchCount = 0;

    private ParticleSystem particleSystem;
    private GameObject reference;
    private Ability ability;

    void Start () {
        ability = new Ability(GetComponentInChildren<SpriteRenderer>());
        particleSystem = GetComponent<ParticleSystem>();
        ballArray = new Ball[amountOfBalls];
  
        reference = GameObject.FindGameObjectWithTag("ball");
        ballArray[ballArray.Length - 1] = reference.GetComponent<Ball>();

        
        

    }
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
        
        
        loopThrough();
        checkStart();
        checkForEnd();

        



    }
    private int tmpCount = 0;
    public void loopThrough() {

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ball"))
            if(obj != null)
                tmpCount++;
        ballCount = tmpCount;
        tmpCount = 0;

        for (int i = 0; i < ballArray.Length; i++)
        {
            if(ballArray[i] != null)
            if (ballArray[i].GetComponent<RectTransform>().position.y > Camera.main.orthographicSize + 1 ||
                ballArray[i].GetComponent<RectTransform>().position.y < -Camera.main.orthographicSize - 1 ||
                ballArray[i].GetComponent<RectTransform>().position.x > (Camera.main.orthographicSize * Camera.main.aspect) + 1 ||
                ballArray[i].GetComponent<RectTransform>().position.x < -(Camera.main.orthographicSize * Camera.main.aspect) - 1) {
                ballArray[i] = null;
            }
            if (ballArray[i] != null && ballArray[i].isOffScreen())
            {
                Destroy(ballArray[i].gameObject);
                ballArray[i] = null;
                
                
            }

        }

    }
    private GameObject tmp;
    public void checkAndReplenish() {
        reference = GameObject.FindGameObjectWithTag("ball");
        for (int i = 0; i < ballArray.Length - 1; i++)
        {
            tmp = (GameObject)Instantiate(reference);
            ballArray[i] = null;
            ballArray[i] = tmp.GetComponent<Ball>();
            stabalizeBegin(ballArray[i]);
            

        }
        
    }
    public void stabalizeBegin(Ball b) {

        b.GetComponent<RectTransform>().position = new Vector2(Random.Range(b.GetComponent<RectTransform>().position.x - 1, b.GetComponent<RectTransform>().position.x + 1), 
            Random.Range(b.GetComponent<RectTransform>().position.y - 1, b.GetComponent<RectTransform>().position.y + 1));
        int rand = Random.Range(0, 3);
        if(rand == 0)
            b.GetComponent<Ball>().setVelocity(b.GetComponent<Ball>().getVelocity().x, b.GetComponent<Ball>().getVelocity().y);
        if (rand == 1)
            b.GetComponent<Ball>().setVelocity(-b.GetComponent<Ball>().getVelocity().x, b.GetComponent<Ball>().getVelocity().y);
        if (rand == 2)
            b.GetComponent<Ball>().setVelocity(-b.GetComponent<Ball>().getVelocity().x, -b.GetComponent<Ball>().getVelocity().y);
        if (rand == 3)
            b.GetComponent<Ball>().setVelocity(b.GetComponent<Ball>().getVelocity().x, -b.GetComponent<Ball>().getVelocity().y);


    }
    public int getBallCount() {
        
        return ballCount;
    }

    void OnTriggerEnter(Collider col)
    {
        //removed touchcount++ then checking if it equals one in condition
        base.checkCollision(col);
    }

    

   

    public void checkStart()
    {
        if (abilityStarted)
        {
            touchCount = 0;
            checkAndReplenish();
        }
    }

    public void checkForEnd()
    {

        if (base.abilityDone())
            abilityStarted = false;
    }

    public void setAvail(bool cond) {
        base.abilityAvailable = cond;
    }
    public bool getAvail() {
        return base.abilityAvailable;
    }
}
