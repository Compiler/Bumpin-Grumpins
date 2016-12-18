using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PaddleCanvas : MonoBehaviour {

    private Image image;
	void Start () {

        image = GetComponent<Image>();
        GetComponent<BoxCollider2D>().size = gameObject.GetComponent<RectTransform>().sizeDelta;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
