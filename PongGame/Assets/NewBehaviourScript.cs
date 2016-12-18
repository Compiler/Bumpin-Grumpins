using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject go;
	void Start () {

        go = GameObject.Find("One");
        Instantiate(go, new Vector3(go.transform.position.x + 2, go.transform.position.y +2, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
