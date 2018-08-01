using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public Spawner spawner;

    public float initSpeed;
    public float maxSpeed;
    public float jumpVelocity;
    public float fallMultiplyer;
    public float lowJumpMultiplyer;
    public float accelerationMultiplyer;
    public float decelerationMultiplyer;
    public float deathTimer;

    private GameObject deathScreen;
    private Image image;
    private GameObject player;

    float speed;

    //Movement vars
    Vector3 direction;

    //Used for time to jump
    double time1;
    bool canJump = false;

    //Declares Object Components
    Transform trans;
    Rigidbody2D rigidbody2D;


    //Called when player is touching something
    void OnTriggerEnter2D(Collider2D collider)
    {
        canJump = true;
        
        if (collider.CompareTag("Respawn"))
        { 
            die();
        }
    }

    //Called when player not touching something
    void OnTriggerExit2D()
    {
        canJump = false;
    }


    Spawner spawn;

    // Use this for initialization
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        spawn = spawner.GetComponent<Spawner>();

        deathScreen = GameObject.Find("DeathScreen");

        GameObject imageObject = GameObject.FindGameObjectWithTag("FadeToBlackTag");
        image = imageObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        player = GameObject.Find("Moonman(Clone)");
    }


    //Function that deals with all the player movement
    void movement()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = initSpeed;
        }

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
        else if (canJump)
        {
            speed -= decelerationMultiplyer;
        }



        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        else if (speed < 0)
        {
            speed = 0;
        }

        trans.eulerAngles = direction;
        
        //Moves the "moonman" horizontally
        trans.Translate(Vector3.right * speed);

        /*
        //Decides whether the "moonman" should jump or not
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && canJump)
        {
            rigidbody2D.AddForce(new Ve]ctor2(0, jump * 100));
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

    
    void die()
    {
        StartCoroutine(waitTimer());
        
    }

    IEnumerator waitTimer()
    {
        deathScreen.GetComponent<Canvas>().enabled = true;
        image.CrossFadeAlpha(0.8f, 0.0f, true);
        player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        player.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        player.gameObject.GetComponent<Player_Controller>().enabled = false;
        image.CrossFadeAlpha(1.0f, 3.0f, true);
        yield return new WaitForSeconds(deathTimer);
        //image.CrossFadeAlpha(0.8f, 5.0f, true);
        yield return new WaitForSeconds(deathTimer);
        deathScreen.GetComponent<Canvas>().enabled = false;
        Destroy(this.gameObject);
        spawn.spawn();
    }

}


