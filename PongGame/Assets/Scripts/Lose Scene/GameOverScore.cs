using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScore : MonoBehaviour {

    private Text gameText, overText, scoreText, numbersText, rankText, rankText2;
    private string game = "Game", over = "over";
    private string[] arrG, arrO;
	void Start () {
        arrG = new string[game.Length];
        arrO = new string[over.Length];
        gameText = GameObject.Find("Canvas/Game").GetComponent<Text>();
        overText = GameObject.Find("Canvas/Over").GetComponent<Text>();
        scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();
        numbersText = GameObject.Find("Canvas/Numbers").GetComponent<Text>();
        rankText = GameObject.Find("Canvas/Rank").GetComponent<Text>();
        rankText2 = GameObject.Find("Canvas/Rank2").GetComponent<Text>();
        for (int i = 0; i < over.Length; i++) {
            arrG[i] = game.Substring(i, 1);
            arrO[i] = over.Substring(i, 1);
        }
        score = TextHandler.score;
	}
    private int score;
    private float time, wroteTime;
    int i = 0;
    private bool wroteText, done;
	void Update () {
        if (done)
        {
            GameObject.Find("Canvas/Button").GetComponent<Image>().color = new Color(
                GameObject.Find("Canvas/Button").GetComponent<Image>().color.r,
                GameObject.Find("Canvas/Button").GetComponent<Image>().color.g,
                GameObject.Find("Canvas/Button").GetComponent<Image>().color.b,
                GameObject.Find("Canvas/Button").GetComponent<Image>().color.a + .01f);
        }
        else
        {
            GameObject.Find("Canvas/Button").GetComponent<Image>().color = new Color(
                GameObject.Find("Canvas/Button").GetComponent<Image>().color.r,
                GameObject.Find("Canvas/Button").GetComponent<Image>().color.g,
                GameObject.Find("Canvas/Button").GetComponent<Image>().color.b,0);
        }

        time += Time.deltaTime;

        if (time > 1) {
            if (i < game.Length)
            {
                gameText.text += arrG[i];
                overText.text += arrO[i];
            }
            else
                wroteText = true;
            
            ++i;
            time = 0;
        }

        if (wroteText)
        {
            wroteTime += Time.deltaTime;
            scoreText.text = "score";
            if (wroteTime < 3)
            {
                scoreText.color = Color.Lerp(Color.blue, Color.black, Mathf.PingPong(Time.time, .5f));
                numbersText.text = "" + Random.Range(0, 9) + "" + Random.Range(0, 9) + "" + Random.Range(0, 9);
            }
            else
            {
                numbersText.text = score + "";
                if (score < 10)
                {
                    numbersText.color = Color.Lerp(Color.black, Color.red, Mathf.PingPong(Time.time, 1f));
                    rankText.color = Color.red;
                    rankText.text = "AWEFUL";
                   
                    
                    if (rankText.fontSize < 15)
                        rankText.fontSize += 1;
                    done = true;
                }
                else if (score > 25)
                {
                    numbersText.color = Color.Lerp(Color.black, Color.magenta, Mathf.PingPong(Time.time, 1f));
                    rankText.color = Color.magenta;
                    if (rankText.fontSize < 15)
                        rankText.fontSize += 1;
                    rankText.text = "JUST bad";
                    done = true;
                }
                else if (score > 50)
                {
                    numbersText.color = Color.Lerp(Color.gray, Color.blue, Mathf.PingPong(Time.time, 1f));
                    rankText.color = Color.blue;
                    if (rankText.fontSize < 15)
                        rankText.fontSize += 1;
                    rankText.text = "Okay";
                    done = true;
                }
                else if (score > 100)
                {
                    numbersText.color = Color.Lerp(Color.cyan, Color.yellow, Mathf.PingPong(Time.time, 1f));
                    rankText.color = Color.Lerp(Color.cyan, Color.yellow, Mathf.PingPong(Time.time, 1f));
                    if (rankText.fontSize < 15)
                        rankText.fontSize += 1;
                    rankText.text = "Good!";
                    done = true;
                }
                rankText2.text = rankText.text;
                rankText2.color = rankText.color;
                rankText2.fontSize = rankText.fontSize;
            }
        }
	}

    public void setSceneMain() {
        SceneManager.UnloadScene("main");
        SceneManager.LoadScene("Main Menu");
    }
}
