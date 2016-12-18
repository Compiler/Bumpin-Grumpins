using UnityEngine;
using System.Collections;

public class Sprite : MonoBehaviour {

    private SpriteRenderer renderer;
    private Sprite sprite;
    private Ability ability;
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
        ability = new Ability(renderer);
	}
	
	// Update is called once per frame
	void Update () {


        ability.updateRenderer(GetComponentInParent<BoxCollider>(), .2f, .2f);
        ability.checkAvailability(GetComponentInParent<PaddleEnlarge>().getAvail());

    }

   

}
