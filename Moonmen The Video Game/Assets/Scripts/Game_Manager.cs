using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
        Spawner spawner = new Spawner();
        spawner.spawn();
	}

}
