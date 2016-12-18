using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text text;
    private string gameover = "Game Over";
    private float elapsed = 0;
    int i = 0;
	void Start () {
        text.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        elapsed += Time.deltaTime;
      

            if (elapsed > .25f && i < gameover.Length)
            {
                text.text += gameover.Substring(i, 1);
                i++;
                elapsed = 0;
            }

	}
}
