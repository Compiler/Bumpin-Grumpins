using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisclaimerRend : MonoBehaviour {

    private Text text;
    public string textToBeDrawn = "Everything you are about to experience is in Alpha.";

    private float time = 0, waiter = 0, total = 0;
    private string []keyset;

    void Start () {
        if(index == 0)
            text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        else
            text = GameObject.Find("Canvas/Text (1)").GetComponent<Text>();

        keyset = new string[textToBeDrawn.Length];

        for (int i = 0; i < textToBeDrawn.Length - 1; i++)
            keyset[i] = textToBeDrawn.Substring(i, 1);
	}


    int i = 0;
    public int index;
    public bool wait;

    private bool start;
    void Update () {
        total += Time.deltaTime;
        if (total > 10.5f) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - .005f);
        }
        print(total);
        
        if (start) {
            if (waiter < .25f)
            {
                text.fontSize += 1;
            }
            else if (waiter < .5f)
            {
                text.fontSize -= 1;
            }
            else
                waiter = 0;

        }
        if(total < 10)
        if(index == 0)
            text.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, .25f));
        else
            text.color = Color.Lerp(new Color(0f, 0, 0f), Color.red, Mathf.PingPong(Time.time, .4f));
        if (!wait)
        {
            time += Time.deltaTime;
            if (time > .1f)
            {
                time = 0;
                text.text += keyset[i];

                i++;

            }
        }
        else
        {
            waiter += Time.deltaTime;
            if (waiter > 6.5f) {
                time += Time.deltaTime;
                if (time > .1f)
                {
                    if(i > 3)
                    if (textToBeDrawn.Substring(i - 1, 1).Equals("t"))
                    {
                        text.text += "\n";
                       
                    }
                    time = 0;
                    
                    
                        text.text += keyset[i];

                    i++;

                }
                if (waiter > 8.5f) {
                    start = true;
                    waiter = 0;
                }

            }
        }



        if (total > 17 || Input.touchCount > 0) {
            SceneManager.LoadScene("Main Menu");
        }
	}
}
