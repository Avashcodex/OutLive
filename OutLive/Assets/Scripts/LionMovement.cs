using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionMovement : MonoBehaviour
{
    public float speed;
    public float speedFrd;
    public float speedJump;
    public float speedIncFactor;
    private float sideMovement;
    private float frontMovement;
    private Rigidbody rb;
    float horiMove = 0f;
    private bool jumpPossible = false;
    private bool flightDuration = true;
    private bool firstJump = false;
    private bool sprint = true;
  


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpPossible)
        {
            jumpPossible = false;
            LionJump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && sprint && jumpPossible)
        {
            StartCoroutine(SpeedIncrease());
        }
    }

    void FixedUpdate()
    {
        Debug.Log(Physics.gravity);

        horiMove = Input.GetAxisRaw("Horizontal") * speed;
        //Debug.Log(flightDuration);
        gameObject.GetComponent<Transform>().position += new Vector3(horiMove, 0f, speedFrd) * Time.deltaTime;

                  
    }
    

    void LionJump()
    {
        Vector3 jumpForce = new Vector3(0f, speedJump, 0f);
        rb.AddForce(jumpForce, ForceMode.Impulse);
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

    IEnumerator SpeedIncrease()
    {
        
        sprint = false;      
        speedFrd += speedIncFactor;
        speed += speedIncFactor;
        yield return new WaitForSeconds(0.7f);
        speedFrd -= speedIncFactor;
        speed -= speedIncFactor;
        sprint = true;

    }
}
