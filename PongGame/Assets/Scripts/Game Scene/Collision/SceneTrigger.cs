using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour {

    private GameObject g;
	void Start () {
        g = GameObject.Find("Specialties");
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ball")
        {
            
            col.gameObject.GetComponent<Ball>().setIsOffScreen(true);
            if (GameObject.Find("Specialties/TrippleBall").GetComponent<TripleBall>().getBallCount() <= 1)
            {

                Debug.Log("Loading next screen...");
                SceneManager.LoadScene("GameOverScene");
            }
            else
                print("BallCount: " + GameObject.Find("Specialties/TrippleBall").GetComponent<TripleBall>().getBallCount());
            
            
        }
        
    }


}
