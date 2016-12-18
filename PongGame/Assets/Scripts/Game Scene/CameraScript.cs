using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    private Camera camera;
	void Start () {

        camera = GetComponent<Camera>();
        Screen.SetResolution(Screen.width, Screen.height, false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
