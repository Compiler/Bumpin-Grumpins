using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Paddle : MonoBehaviour {

	public Vector3 playerPos;
	public float paddleSpeed = 15F;
    public float yClamp;
    private float yPos = 0;
    public static Vector3 dimensions;
    private SpriteRenderer renderer;
    private int index;
    private bool isPaused;
    
    float xPos;
	void Start () {
        
        renderer = GetComponent<SpriteRenderer>();

        dimensions = new Vector3(transform.localScale.x, transform.localScale.y, 0);
        float y = Screen.height / renderer.sprite.pixelsPerUnit;
        y = y / 6;

        float x = Screen.width / renderer.sprite.pixelsPerUnit;
        x = x / (Camera.main.orthographicSize * Camera.main.aspect);
        transform.localScale = new Vector3(x, y, 1);
        

        //renderer is the SpriteRenderer
       xPos = ((-Camera.main.orthographicSize * Camera.main.aspect) +
            ((renderer.sprite.textureRect.width / renderer.sprite.pixelsPerUnit) / 2f));

       // GameObject.Find("padL").GetComponent<Image>().;
        paddleSpeed = 10f;
        
    }

    // Update is alled once per frame
    private Vector2 s;
    private Touch myTouch;
    private Vector3 mousePos, touchPos;
    string side = "not touched";
    void Update() {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //checkMovementDesktop();
        checkMovementMouse();
        
            checkTouchIndex();
        if (Input.touchCount > 0 && index != -1) {
            touchPos = Camera.main.ScreenToWorldPoint(myTouch.position);
            
            if (touchPos.x < 0)
            {
                
                //Begin Section: Touch left side
                if (touchPos.y > 0)
                {
                    
                    move(touchPos.y);
                }
                else
                {
                    
                    move(touchPos.y);
                }
                //End of section
            }
            
    }


        

       
        

        playerPos.Set(xPos, Mathf.Clamp(yPos, -yClamp, yClamp), 0);

		gameObject.transform.position = playerPos;

        Debugger.l = "Left X: " + touchPos.x;
    }

    public void checkTouchIndex() {
        /*   if (Input.touchCount < 1)
           {
               touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
               if (touchPos.x < 0)
               {
                   Debugger.il = "Touch Index = 0";
                   myTouch = Input.GetTouch(0);
               }

           }
           if (Input.touchCount <= 1)
           {
               touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
               if (touchPos.x < 0)
               {

                   Debugger.il = "Touch Index = 1";
                   myTouch = Input.GetTouch(1);

               }
           }
           else
               Debugger.il = "Side not touched";*/
               if(Input.touchCount > 0)
                     myTouch = Input.GetTouch(index);
    }
    public void move(float pos) {
        if(!isPaused)
            yPos = pos;
    }

    /*public void checkMovementDesktop() {
        if (Input.GetKey(KeyCode.W))
        {
            move(true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            move(false);
        }

    }*/

    public void checkMovementMouse() {
        if (Input.GetMouseButton(0) && !Input.touchSupported)
        {


            if (Input.mousePosition.x < Screen.width / 2)
            {
                move(Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            }

        }
    }

    public void resetPaddleSize() {

        transform.localScale = dimensions;
    }

    public void setInitialPosition()
    {
        playerPos.Set(xPos, 0, 0);

        yClamp = Mathf.Abs((Camera.main.orthographicSize -
            ((renderer.sprite.textureRect.height / renderer.sprite.pixelsPerUnit) / 2f)) * 2.25f);
    }

    public void setIndex(int k) {

        index = k;
    }
    public void setIsPaused(bool cond)
    {
        this.isPaused = cond;

    }
}
