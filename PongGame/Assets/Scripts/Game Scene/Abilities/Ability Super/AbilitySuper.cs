using UnityEngine;
using System.Collections;

public class AbilitySuper : MonoBehaviour {

    protected bool abilityStarted, abilityAvailable, assigned;
    protected float meshStayTime, maxAbilityTime, abilityAliveTime;
    public static readonly int maxAvailibilityTime = 5;
    //Default constructor
    public AbilitySuper() {

    }

    //Constructor for timed events
    public AbilitySuper(float abilityTime) {
        this.maxAbilityTime = abilityTime;
    }

    protected void initTimed(float abilityTime) {
        this.maxAbilityTime = abilityTime;
    }
	void Start () {
	
	}
	
	
	protected virtual void Update () {
        if (abilityStarted) {
            abilityAliveTime += Time.deltaTime;
        }
        checkMesh();
	}


    protected void checkForAvailabilityEnd() {
        if (meshStayTime > maxAvailibilityTime) {
            abilityAvailable = false;
            meshStayTime = 0;
        }

    }
    public void assignPosition()
    {

        if (assigned == false)
            transform.position = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
        assigned = true;
    }
    protected void checkCollision(Collider col)
    {

        if (abilityAvailable)
            if (col.gameObject.tag == "ball" && abilityAvailable)
            {
                //If collided with ability, start ability and turn off option to hit ability
                abilityStarted = true;
                abilityAliveTime = 0;
                abilityAvailable = false;

            }

    }

    public void checkMesh()
    {

        if (abilityAvailable)
        {
            assignPosition();
            //Start timer
            meshStayTime += Time.deltaTime;
            
            //Turn on Mesh
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<ParticleSystem>().Play();
            GetComponentInChildren<SpriteRenderer>().enabled = true;

        }
        else
        {
            //Turn off mesh
            GetComponent<MeshRenderer>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            GetComponent<ParticleSystem>().Pause();
            GetComponent<ParticleSystem>().Clear();

            //Reset timer
            meshStayTime = 0;

            assigned = false;
        }
    }

    protected bool abilityDone() {
        if (maxAbilityTime <= abilityAliveTime)
        {
            abilityAliveTime = 0;
            return true;
        }
        else
            return false;
    }
}
