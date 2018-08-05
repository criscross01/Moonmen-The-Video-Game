using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationController : MonoBehaviour {

    public Animator animations;
    private GameObject player;

    // Use this for initialization
    void Update()
    {
        player = GameObject.Find("Moonman(Clone)");
  
        animations = player.gameObject.GetComponent<Animator>();

        Scene currentScene = SceneManager.GetActiveScene();

        int buildIndex = currentScene.buildIndex;


        switch (buildIndex)
        {
            case 2:
                animations.Play("Man[AllGrey]");
                break;

            case 4:
                animations.Play("Man[Yellow]");
                break;
            /*
            case 6:
                animations.Play("Man[]");
                break;
            */
        }
    }
}
