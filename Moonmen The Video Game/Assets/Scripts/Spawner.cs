using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    public GameObject Moonman;
    public GameObject Camera;
    public GameObject Background;
    public float x;
    public float y;
    public float z;

    private PlayerCamera camera;
    private PlayerCamera background;
    private Player_Controller pc;

    private GameObject player;

    private void Start()
    {
        camera = Camera.GetComponent<PlayerCamera>();
        background = Background.GetComponent<PlayerCamera>();
        pc = Moonman.GetComponent<Player_Controller>();
        pc.spawner = this;

        spawn();
    }

    public void spawn()
    {

        player = Instantiate(Moonman);
        player.transform.position = new Vector3(x, y, z);

        camera.target = player.transform;

        background.target = player.transform;

    }

}
