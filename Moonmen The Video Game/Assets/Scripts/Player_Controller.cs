using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public int speed = 8;
    public int jump = 3;

    //Used for time to jump
    public double jumpTime = 1;
    double time1;

    //Declares Object Components
    Transform trans;
    Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start () {
        trans = gameObject.GetComponent<Transform>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        movement();
    }




    //Function that deals with all the player movement
    void movement()
    {
        //This gets the Input from the user
        float xInput = Input.GetAxis("Horizontal");

        //Determines which way that the "moonman" is facing
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            trans.eulerAngles = new Vector3(0, 0);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            trans.eulerAngles = new Vector3(0, 180);
        }


        //Basically makes the "moonman" go the right way
        if (xInput < 0)
        {
            xInput *= -1;
        }



        //Gets final speed that the "moonman" will go at
        float xVec = xInput * (float)(speed * .01);



        //Moves the "moonman" horizontally
        trans.Translate(new Vector3(xVec, 0));

        

        //Decides whether the "moonman" should jump or not
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && jumpTime <= Time.time-time1)
        {
            rigidbody2D.AddForce(new Vector2(0, jump * 100));
            time1 = Time.time;
        }
    }
}
