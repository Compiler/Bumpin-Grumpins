using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour {

    public static int score = 0;
    public Text text;
    void Start()
    {
        if (text != null)
        {
            text.transform.position.Set(0, 0, 0);
            text.text = "0";
        }
    }
	// Update is called once per frame
	void Update () {
        text.text = "" + score;
	}
}
