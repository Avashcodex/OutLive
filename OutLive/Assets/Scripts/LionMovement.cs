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
    public GameObject player;
    public float rotationFactor;
    public float rotationSmooth;




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
      

        

        horiMove = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetKey(KeyCode.A))
        {
            Quaternion target = Quaternion.Euler(0f, -rotationFactor, 0f);
            player.GetComponent<Transform>().rotation = Quaternion.Slerp(player.GetComponent<Transform>().rotation,target,Time.deltaTime*rotationSmooth);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            Quaternion target = Quaternion.Euler(0f, rotationFactor, 0f);
            player.GetComponent<Transform>().rotation = Quaternion.Slerp(player.GetComponent<Transform>().rotation, target, Time.deltaTime * rotationSmooth);
        }
        else
        {
            Quaternion target = Quaternion.Euler(0f, 0f, 0f);
            player.GetComponent<Transform>().rotation = Quaternion.Slerp(player.GetComponent<Transform>().rotation, target, Time.deltaTime * rotationSmooth);

           

        }



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
