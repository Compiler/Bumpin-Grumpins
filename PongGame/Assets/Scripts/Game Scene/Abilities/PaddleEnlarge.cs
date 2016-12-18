using UnityEngine;
using System.Collections;

public class PaddleEnlarge : AbilitySuper {

    // Use this for initialization
    public static float tmp = 0;

    private float maxScale;

    private new ParticleSystem particleSystem;

    void Start() {

        maxScale = GameObject.Find("Paddle Left Canvas").GetComponent<RectTransform>().localScale.y
            + (GameObject.Find("Paddle Left Canvas").GetComponent<RectTransform>().localScale.y/2);
        
        particleSystem = GetComponent<ParticleSystem>();

        initTimed(20);
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();

        checkStart();

        checkForEnd();

        if (Input.GetKeyDown(KeyCode.R))
            startAbility();
        

    }
    void OnTriggerEnter(Collider col)
    {
        checkCollision(col);
      
    }

    public void startAvailability() {
        abilityAvailable = true;
    }
    
    public void checkStart() {
        if (abilityStarted)
        {
            
            startAbility();
            
        }
    }

    public void checkForEnd() {
        if (abilityDone())
        {
            GameObject.Find("Canvas/Paddle Left Canvas").GetComponent<AttemptChange>().resetPaddleSize();
            GameObject.Find("Canvas/Paddle Right Canvas").GetComponent<AttemptChangeRight>().resetPaddleSize();
            abilityStarted = false;
        }
    }
    public bool getAvail() {
        return base.abilityAvailable;
    }
    private float expandTime = 0;
    public void startAbility() {
        expandTime += Time.deltaTime;
        print(GameObject.Find("Canvas/Paddle Left Canvas").name + ": herpes");
        if (GameObject.Find("Canvas/Paddle Left Canvas").GetComponent<RectTransform>().localScale.y < maxScale)
        {
            GameObject.Find("Canvas/Paddle Left Canvas").GetComponent<RectTransform>().localScale =
                new Vector3(GameObject.Find("Canvas/Paddle Left Canvas").GetComponent<RectTransform>().localScale.x, GameObject.Find("Canvas/Paddle Left Canvas").GetComponent<RectTransform>().localScale.y + (expandTime / 2), 1);
            GameObject.Find("Canvas/Paddle Right Canvas").GetComponent<RectTransform>().localScale = GameObject.Find("Canvas/Paddle Right Canvas").GetComponent<RectTransform>().localScale;
        }
        else
        {
            GameObject.Find("Canvas/Paddle Left Canvas").GetComponent<RectTransform>().localScale = 
                new Vector3(GameObject.Find("Canvas/Paddle Left Canvas").GetComponent<RectTransform>().localScale.x, maxScale, 1);

            GameObject.Find("Canvas/Paddle Right Canvas").GetComponent<RectTransform>().localScale =
                new Vector3(GameObject.Find("Canvas/Paddle Right Canvas").GetComponent<RectTransform>().localScale.x, maxScale, 1);
        }

    }
}
