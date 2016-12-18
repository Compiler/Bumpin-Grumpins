using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchIndexer : MonoBehaviour
{

    private Paddle paddleLeft;
    private PaddleRight paddleRight;
    private Vector3 touch;
    void Start()
    {

       
    }

    int left, right;
    void Update()
    {
       

        for (int i = 0; i < Input.touchCount; i++)
        {
            
            if(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position).x < 0)
            {
                left = i;
            }
            else
                right = i;
            
        }
           
            GameObject.Find("Canvas/Paddle Left Canvas").GetComponent<AttemptChange>().setIndex(left);
            GameObject.Find("Canvas/Paddle Right Canvas").GetComponent<AttemptChangeRight>().setIndex(right);
               
            
        


    }

}