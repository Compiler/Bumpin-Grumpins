using UnityEngine;
using System.Collections;

public class ScoreHandler : MonoBehaviour {

    public UnityEngine.Sprite ones;
    public UnityEngine.Sprite tens;
    public UnityEngine.Sprite hundreds;
    private string[] tuples = new string[10];
    private string directory = "Pong/Numbers";

    private SpriteRenderer rOnes, rTens, rHuns;
    float r = 0, g = 0, b = 0;
    void Start () {
        rOnes = GameObject.Find("EnhancedTextHandler/Ones").GetComponent<SpriteRenderer>();
        rTens = GameObject.Find("EnhancedTextHandler/Tens").GetComponent<SpriteRenderer>();
        rHuns = GameObject.Find("EnhancedTextHandler/Hundreds").GetComponent<SpriteRenderer>();

        rOnes.transform.position = new Vector3(rOnes.transform.localScale.x * 2.1f, Camera.main.orthographicSize - (rOnes.transform.localScale.y * 2), 0);
        rTens.transform.position = new Vector3(0, Camera.main.orthographicSize - (rOnes.transform.localScale.y * 2), 0);
        rHuns.transform.position = new Vector3(-rOnes.transform.localScale.x * 2.1f, Camera.main.orthographicSize - (rOnes.transform.localScale.y * 2), 0);

        ones = Resources.Load < UnityEngine.Sprite > ("Pong/Numbers/1black");
        initStrings("white");
    }
	
	// Update is called once per frame
	void Update () {
        updateImage();
	}
    private int onesCount = 0;
    public void updateImage() {
        
        reposition(TextHandler.score);
        addColor();
        spriteChanging();
        if (Input.GetKey(KeyCode.L))
            TextHandler.score = 99;
    }

    public void initStrings(string color) {
        for(int i = 0; i < tuples.Length; i++)
            tuples[i] = directory + "/"+i+""+color;

    }
  
    public void spriteChanging() {

        ones = Resources.Load<UnityEngine.Sprite>(tuples[TextHandler.score % 10]);
        
        if(TextHandler.score > 9)
            tens = Resources.Load<UnityEngine.Sprite>(tuples[(TextHandler.score / 10) % 10]);


        if (TextHandler.score > 99)
            hundreds = Resources.Load<UnityEngine.Sprite>(tuples[(TextHandler.score / 100) % 10]);


        rOnes.sprite = ones;
        rTens.sprite = tens;
        rHuns.sprite = hundreds;

    }
    float timer = 0;
    private Color lerper;
    public void addColor() {
        
        rOnes.color = Color.Lerp(lerper, Color.black, Mathf.PingPong(Time.time, 5f));
        rTens.color = Color.Lerp(lerper, Color.black, Mathf.PingPong(Time.time, 5f));
        rHuns.color = Color.Lerp(lerper, Color.black, Mathf.PingPong(Time.time, 5f));
        
    }
    public void reposition(int score) {
        if (score < 10) {
            rOnes.transform.position = new Vector3(0, Camera.main.orthographicSize - (rOnes.transform.localScale.y * 2), 0);
        }
        if (score > 9 && score < 100)
        {
            rOnes.transform.position = new Vector3(rOnes.transform.localScale.x * 1.1f, Camera.main.orthographicSize - (rOnes.transform.localScale.y * 2), 0);
            rTens.transform.position = new Vector3(rTens.transform.localScale.x * -1.1f, Camera.main.orthographicSize - (rOnes.transform.localScale.y * 2), 0);
        }

        if (score > 99)
        {
            rOnes.transform.position = new Vector3(rOnes.transform.localScale.x * 2f, Camera.main.orthographicSize - (rOnes.transform.localScale.y * 2), 0);
            rTens.transform.position = new Vector3(0, Camera.main.orthographicSize - (rOnes.transform.localScale.y * 2), 0);
            rHuns.transform.position = new Vector3(rHuns.transform.localScale.x * -2f, Camera.main.orthographicSize - (rOnes.transform.localScale.y * 2), 0);
        }

    }
}
