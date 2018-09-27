using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjects : MonoBehaviour
{
    public float fallDelay;
    private GameObject cam;
    Vector3 lastTargetPosition;
    Vector3 shakePosition;

    public void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Moonman(Clone)")
        {
            lastTargetPosition = cam.transform.position;
            shakePosition = lastTargetPosition + new Vector3(0.2f, 0.2f, 0);
            StartCoroutine(Fall()); 
        }
    }
        
    IEnumerator Fall()
    {
        cam.gameObject.transform.position = shakePosition;
        cam.gameObject.transform.localScale = lastTargetPosition;
        cam.gameObject.transform.position = shakePosition;
        cam.gameObject.transform.localScale = lastTargetPosition;
        cam.gameObject.transform.position = shakePosition;
        yield return new WaitForSeconds(fallDelay);
        cam.gameObject.transform.localScale = lastTargetPosition;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
}