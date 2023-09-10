using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float speedRotation;
	public float forceJump;
	public bool isJumping;
	public Rigidbody rigidBody;
	public bool isGrounded;
	private float x, y;
	private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    	isJumping = false;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
    	transform.Rotate(0, x * Time.deltaTime * speedRotation, 0);
        transform.Translate(0, 0, y * Time.deltaTime * moveSpeed);
    }


    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animator.SetFloat("Xspeed", x);
        animator.SetFloat("Yspeed", y);

        if(isJumping)
        {
        	if(Input.GetKeyDown(KeyCode.Space))
        	{
        		animator.SetBool("IsJumping", true);
        		rigidBody.AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse);
        	}

        	animator.SetBool("IsGrounded", true);
        }
        else
        {
        	Falling();
        }
    }

    public void Falling()
    {
    	animator.SetBool("IsGrounded", false);
    	animator.SetBool("IsJumping", false);
    }
}
