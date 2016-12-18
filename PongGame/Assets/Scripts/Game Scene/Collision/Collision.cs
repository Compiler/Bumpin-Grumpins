using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour {


	public Text t;
	private int counter;
    void Start() {
       
	}
	

	void Update () {
		
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "paddle") {

            TextHandler.score += 1;
			
		}
        
	}
}
