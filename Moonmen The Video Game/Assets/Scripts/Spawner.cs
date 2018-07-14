using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    public GameObject moonman;

    public void spawn()
    {

        Instantiate(moonman);

         PlayerCamera cam = GameObject.Find("Main Camera");
         

    }

}
