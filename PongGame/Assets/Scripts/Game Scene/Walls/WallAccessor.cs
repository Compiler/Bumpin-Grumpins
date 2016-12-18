using UnityEngine;
using System.Collections;

public class WallAccessor : MonoBehaviour {


    
    private Vector3 locScl = new Vector3(0.1f, 30, 0);

    void Start () {

        GameObject topWall = GameObject.Find("Top");
        topWall.transform.localScale = new Vector3(locScl.y, locScl.x, 0);
        topWall.transform.position = new Vector3(0, Camera.main.orthographicSize + (topWall.transform.localScale.y / 2), 0);

        GameObject bottomWall = GameObject.Find("Bottom");
        bottomWall.transform.localScale = new Vector3(locScl.y, locScl.x, 0);
        bottomWall.transform.position = new Vector3(0, -Camera.main.orthographicSize - (bottomWall.transform.localScale.y / 2), 0);

        GameObject leftWall = GameObject.Find("LBackBoard");
        leftWall.transform.localScale = new Vector3(locScl.x, locScl.y, 0);
        leftWall.transform.position = new Vector3(-Camera.main.orthographicSize * Camera.main.aspect - (leftWall.transform.localScale.x / 2), 0, 0);
       
        GameObject rightWall = GameObject.Find("RBackBoard");
        rightWall.transform.localScale = new Vector3(locScl.x, locScl.y, 0);
        rightWall.transform.position = new Vector3(Camera.main.orthographicSize * Camera.main.aspect + (rightWall.transform.localScale.x / 2), 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
