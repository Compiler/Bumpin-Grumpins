using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TempScriptCenter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<RectTransform>().position = 
            new Vector3(0, GetComponent<RectTransform>().position.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
