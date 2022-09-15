using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float speedFrd;
    public float speedJump;
    private float sideMovement;
    private float frontMovement;
    private Rigidbody rb;
    float horiMove = 0f;
    private bool jumpPossible = false;
    private bool flightDuration = true;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        horiMove = Input.GetAxisRaw("Horizontal") * speed;
        //Debug.Log(flightDuration);
        gameObject.GetComponent<Transform>().position += new Vector3(horiMove, 0f, speedFrd) * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && jumpPossible)
        {
            jumpPossible = false;
            GrassHopperJump();
            StartCoroutine(FlightDelay());

        }

        if (Input.GetKey(KeyCode.Space) && flightDuration && !jumpPossible)   //Changing gravity
        {
            Physics.gravity = new Vector3(0f, -2f, 0f);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Physics.gravity = new Vector3(0f, -17f, 0f);
        }
    }

    void GrassHopperJump()
    {
        Vector3 jumpForce = new Vector3(0f, speedJump, 0f);
        rb.AddForce(jumpForce, ForceMode.Impulse);
    }

    IEnumerator FlightDelay()
    {
        flightDuration = false;
        yield return new WaitForSeconds(0.85f);
        flightDuration = true;
    }

    private void OnCollisionEnter(Collision collision)  //groundTouch checking
    {
        Debug.Log("YESS");

        if (collision.collider.CompareTag("GroundCheck"))
        {
            Debug.Log("Ground");
            jumpPossible = true;
        }
    }
}
