using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMain : MonoBehaviour {

    float time = 0;

    private GameObject obj;
	void Start () {
        obj = GameObject.Find("Canvas/Background");

        GameObject.Find("Audio Source").GetComponent<AudioSource>().Pause();
        start = true;
    }

    float otherTime = 0;
	void Update () {

        Time.timeScale = 1;
           
            
            time += Time.deltaTime;
            if (time < 3)
            {
                otherTime += Time.deltaTime;
                if (otherTime > .8f)
                {
                    GameObject.Find("Canvas/Text").GetComponent<Text>().text += ".";
                    otherTime = 0;
                }
                if (time > 2)
                    GameObject.Find("Canvas/Text").GetComponent<Text>().color = new Color(GameObject.Find("Canvas/Text").GetComponent<Text>().color.r,
                        GameObject.Find("Canvas/Text").GetComponent<Text>().color.g, GameObject.Find("Canvas/Text").GetComponent<Text>().color.b,
                        GameObject.Find("Canvas/Text").GetComponent<Text>().color.a - .1f);

            }
            else
            {
                obj.GetComponent<Image>().color =
                    new Color(obj.GetComponent<Image>().color.r, obj.GetComponent<Image>().color.g, obj.GetComponent<Image>().color.b, obj.GetComponent<Image>().color.a + .01f);
                GameObject.Find("Audio Source").GetComponent<AudioSource>().UnPause();

            }
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.UnloadScene("main");
                SceneManager.UnloadScene("Main Menu");
                destroyAll();
                SceneManager.LoadScene("main");
            
        }
	}
    private bool start;
    public void destroyAll() {
        time = otherTime = 0;
        //start = false;
    }
}
