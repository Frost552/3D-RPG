using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController CC;
    [SerializeField]
    bool isGrounded;

    public Vector3 velocity;

    float gravity = -9.81f;
    public Transform groundCheck;
    public float speed;
    public float jumpHeight;
    public float rotateSpeed;
    public float angle;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    CallAnimation anim;
   
    void Start()
    {
        anim = GetComponentInChildren<CallAnimation>();
        CC = GetComponent<CharacterController>();
        if (speed == 0.0f)
            speed = 10.0f;
        if (jumpHeight == 0.0f)
            jumpHeight = 10.0f;
        if (rotateSpeed == 0.0f)
            rotateSpeed = 10.0f;
        


    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<CharacterData>().GetAlive() == true)
        {
            CC.enabled = true;
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float strafe = Input.GetAxisRaw("Strafe");

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            GetComponent<CharacterController>().Move(velocity * Time.deltaTime);

            Vector3 move = (transform.right * strafe) + (transform.forward * vertical);

            angle += horizontal * Time.deltaTime * rotateSpeed;
            transform.rotation = Quaternion.Euler(0, angle, 0);

            CC.Move(move * speed * Time.deltaTime);

            if (vertical > 0)
            {
                anim.SetAnimation("isWalking", true);
                anim.SetAnimation("Speed", vertical);
            }
            if (vertical < 0)
            {
                anim.SetAnimation("isWalking", true);
                anim.SetAnimation("Speed", -vertical);
            }
            if (vertical == 0)
            {
                anim.SetAnimation("isWalking", false);
                anim.SetAnimation("Speed", vertical);
            }
        }
        if(this.GetComponent<CharacterData>().GetAlive() == false)
            CC.enabled = false;
           
    }
}
