using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Debugger : MonoBehaviour{

    public Text debugText, left, right, itl, itr;
    public static string tmp, l, r, il, ir;

    void Start() {

        if (debugText != null)
            debugText.text = "debug";
        else
            debugText.text = "Listening...";
        tmp = l = r = il = ir = "Listening...";
       

    }

    void Update() {
        debugText.text = tmp;
        left.text = l;
        right.text = r;
        itl.text = il;
        itr.text = ir;
    }
	
    
}
