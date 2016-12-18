using UnityEngine;
using System.Collections;

public class PaddleRight : MonoBehaviour
{

    public Vector3 playerPos;
    public float paddleSpeed = 15F;
    public float yClamp;
    public static Vector3 dimensions;
    private float xPos;
    private SpriteRenderer renderer;
    private Vector3 scalarVec;
    void Start()
    {
        paddleSpeed = 10f;
        dimensions = new Vector3(transform.localScale.x, transform.localScale.y, 0);

        renderer = GetComponent<SpriteRenderer>();


        float y = Screen.height / renderer.sprite.pixelsPerUnit;
        y = y / 6;

        float x = Screen.width / renderer.sprite.pixelsPerUnit;
        x = x / (Camera.main.orthographicSize * Camera.main.aspect);

        scalarVec = new Vector3(x, y,1);
        transform.localScale = scalarVec;
        xPos = ((Camera.main.orthographicSize * Camera.main.aspect) -
             ((renderer.sprite.textureRect.width / renderer.sprite.pixelsPerUnit) / 2f));
    }


    // Update is alled once per frame
    float yPos;
    Vector3 mousePos, touchPos;
    Touch myTouch;
    string side = "No side touched";
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);







        checkMovementTouch();
        //checkMovementDesktop();
        checkMovementMouse();


        playerPos.Set(xPos, Mathf.Clamp(yPos, -yClamp, yClamp), 0);
        

        gameObject.transform.position = playerPos;
    }

    public void move(float pos) {
            yPos = pos;


    }

    
    public void checkTouchIndex() {
        /*if (Input.touchCount < 1)
        {
            if (touchPos.x > 0)
            {
                touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                myTouch = Input.GetTouch(0);
                Debugger.ir = "Touch Index = 0";
            }

        }
        if (Input.touchCount <= 1)
        {
            if (touchPos.x > 0)
            {
                Debugger.ir = "Touch Index = 1";
                myTouch = Input.GetTouch(1);
                touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
            }
        }*/
        if(Input.touchCount > 0)
        myTouch = Input.GetTouch(index);
    }
    public void checkMovementTouch() {
            //assigns touch index
            checkTouchIndex();
        if (Input.touchCount > 0 && index != -1)
        {

            touchPos = Camera.main.ScreenToWorldPoint(myTouch.position);

            if (touchPos.x > 0)
            {

                move(touchPos.y);
            }

        }

    }
    private int index;
    public void setIndex(int k)
    {

        index = k;
    }

   /* public void checkMovementDesktop() {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move(true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move(false);
        }

    }*/

    public void checkMovementMouse() {

        if (Input.GetMouseButton(0) && !Input.touchSupported)
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                move(Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            }

        }
    }

    public void setInitialPosition() {
        playerPos.Set(xPos, 0, 0);

        renderer = GetComponent<SpriteRenderer>();
        
        yClamp = Mathf.Abs((Camera.main.orthographicSize - 
            ((renderer.sprite.textureRect.height / renderer.sprite.pixelsPerUnit)/2f))*2.25f);
        
        
    }

    public void resetPaddleSize()
    {

        transform.localScale = dimensions;
    }

    
}
