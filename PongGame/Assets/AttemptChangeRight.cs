using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttemptChangeRight : MonoBehaviour {

    float xPos, yPos;
    private Image renderer;
    private bool isPaused;

    Vector3 scalarVec;
    void Start()
    {

        renderer = GetComponent<Image>();
        float canvasHeight = GetComponentInParent<Canvas>().pixelRect.height;

        scalarVec = new Vector3(1, (Screen.height / 3.5f) / GetComponent<Image>().sprite.pixelsPerUnit, 1);

        GetComponent<BoxCollider>().transform.localScale = scalarVec;


        xPos = ((Camera.main.orthographicSize * Camera.main.aspect) -
              ((renderer.sprite.textureRect.width / renderer.sprite.pixelsPerUnit) / 2f));

    }

    private Vector3 touchPos = new Vector3();
    void Update()
    {
        checkForPause();
        checkMovementMouse();
        renderer.transform.position = new Vector3(xPos, yPos, 0);

        checkTouchIndex();
        if (Input.touchCount > 0 && index != -1)
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(index).position);

            if (touchPos.x > 0)
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


    }
    private Touch myTouch;
    public void checkTouchIndex()
    {
        if (Input.touchCount > 0)
            myTouch = Input.GetTouch(index);
    }
    public void checkMovementMouse()
    {
        if (Input.GetMouseButton(0) && !Input.touchSupported)
        {


            if (Input.mousePosition.x > Screen.width / 2)
            {
                move(Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            }

        }
    }

    public void move(float pos)
    {
        if (!isPaused)
            yPos = pos;
    }
    private int index;
    public void setIndex(int k)
    {

        index = k;
    }

    public void checkForPause() {
        isPaused = GameObject.Find("Pause").GetComponent<Pause>().isPaused();

    }
   

    public void resetPaddleSize()
    {
        GetComponent<BoxCollider>().transform.localScale = scalarVec;

    }
}
