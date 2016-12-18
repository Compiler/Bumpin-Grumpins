using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour {


    private bool pause = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


       

        pauseGame(pause);
        

	}

    

    public void pauseGame(bool cond) {
        if (cond)
        {
            Time.timeScale = 0;
            GameObject.Find("MenuCanvas/MenuImage").GetComponent<Image>().canvasRenderer.SetAlpha(1);


        }
        else {
            Time.timeScale = 1;
            GameObject.Find("MenuCanvas/MenuImage").GetComponent<Image>().canvasRenderer.SetAlpha(0);

        }
    }
    public void resume() {
        if(pause == true)
            this.pause = false;
        
    }
    public void pauseGame() {
        this.pause = true;
    }
    public bool isPaused() { return this.pause; }
}
