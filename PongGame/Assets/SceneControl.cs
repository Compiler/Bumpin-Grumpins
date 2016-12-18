using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {

    public void loadHomeScreen() {

        if (GameObject.Find("Pause").GetComponent<Pause>().isPaused()) {
            SceneManager.UnloadScene("main");
            SceneManager.LoadScene("Main Menu");
            print("loading");
        }
    }
}
