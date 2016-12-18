using UnityEngine;
using System.Collections;

public class ScalarBack : MonoBehaviour {

    private SpriteRenderer render;
	void Start () {

        render = GetComponent<SpriteRenderer>();

        transform.localScale = new Vector3(1, 1, 1);

        float width = render.sprite.bounds.size.x;
        float height = render.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 xWidth = transform.localScale;

        xWidth.x = worldScreenWidth / width + 1;
        transform.localScale = xWidth;

        Vector3 yHeight = transform.localScale;
        yHeight.y = worldScreenHeight / height;

        transform.localScale = yHeight;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
