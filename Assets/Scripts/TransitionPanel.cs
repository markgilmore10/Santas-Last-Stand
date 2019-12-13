using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TransitionPanel : MonoBehaviour
{
    void Start()
    {

    }

    public void LoadScene(string scene) {

    }

    public void TransitionPlay() {
        SceneManager.LoadScene ("BasicMovementAndAnim");
    }

    public void TransitionAbout() {
        SceneManager.LoadScene ("About");
    }

    public void TransitionHome() {
        SceneManager.LoadScene ("MainMenu");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
