using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour {

    private SpriteRenderer rend;
	void Start () {
        rend = GetComponent<SpriteRenderer>();
        rend.transform.position = new Vector3(0, 0, 0);
       

        for (float i = 0; i <= 10;) {
            break;
            if (rend.transform.localScale.x * i == Screen.currentResolution.width) {
                rend.transform.localScale = 
                    new Vector3(i * rend.transform.localScale.x, rend.transform.localScale.y, 0);
                print("resolution met");
                break;
            }
            if (rend.transform.localScale.x * i > Screen.currentResolution.width)
            {
                i = i / 2;
                print("Too large: " + (rend.transform.localScale.x * i) + " | Trying to meet: " +
                    Screen.currentResolution.width);
            }
            else {
                i = i * 2;
                print("Too Small: " + (rend.transform.localScale.x * i) + " | Trying to meet: " +
                    Screen.currentResolution.width);
            }
            
        }
        print("result: " + rend.transform.localScale.x);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {
            SceneManager.UnloadScene("main");
            SceneManager.LoadScene("main");
            print("switch");
        }
	}
}
