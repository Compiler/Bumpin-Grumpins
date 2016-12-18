using UnityEngine;
using System.Collections;

public class Ability {


    protected SpriteRenderer renderer;
    public Ability(SpriteRenderer r) {
        renderer = r;
        
    }

	public void Start () {
        
	}
	
	
	void Update () {
	
	}

    public void checkAvailability(bool avail)
    {
        
        if (avail)
        {
            renderer.enabled = true;
        }
        else
            renderer.enabled = false;
    }

    public void updateRenderer(BoxCollider b, float xScl, float yScl)
    {

        renderer.enabled = true;
        renderer.transform.position = b.transform.position;

        renderer.transform.localScale = new Vector3(xScl, yScl, 0);

    }
}
