﻿using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public float maxSpeed;
    public float jumpVelocity;
    public float fallMultiplyer;
    public float lowJumpMultiplyer;
    public float accelerationMultiplyer;

    float speed;

    //Movement vars
    Vector3 direction;

    //Used for time to jump
    double time1;
    bool canJump = true;

    //Declares Object Components
    Transform trans;
    Rigidbody2D rigidbody2D;

    //Called when player is touching something
    void OnCollisionEnter2D()
    {
        canJump = true;
    }

    //Called when player not touching something
    void OnCollisionExit2D()
    {
        canJump = false;
    }



    // Use this for initialization
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void FixedUpdate()
    {

        //Updates movement every frame
        
    }


    //Function that deals with all the player movement
    void movement()
    {
        //This gets the Input from the user
        float xInput = Input.GetAxis("Horizontal");

        //Determines which way that the "moonman" is facing
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = new Vector3(0, 0);
            speed += accelerationMultiplyer;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = new Vector3(0, 180);
            speed += accelerationMultiplyer;
        }
        else
        {
            speed = 0;
        }

        Debug.Log(speed);

        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        trans.eulerAngles = direction;


        //Basically makes the "moonman" go the right way
        if (xInput < 0)
        {
            xInput *= -1;
        }


        //Gets final speed that the "moonman" will go at
        float xVec = xInput * maxSpeed;

        
        //Moves the "moonman" horizontally
        trans.Translate(Vector3.right * speed);

        /*
        //Decides whether the "moonman" should jump or not
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && canJump)
        {
            rigidbody2D.AddForce(new Vector2(0, jump * 100));
            time1 = Time.time;
        }
        */
        
        if (Input.GetButtonDown("Jump") && canJump)
        {
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
        }


        if (rigidbody2D.velocity.y < 0)
        {
            rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplyer - 1) * Time.deltaTime;
        }

        if (rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplyer * Time.deltaTime;
        }
    }
}
