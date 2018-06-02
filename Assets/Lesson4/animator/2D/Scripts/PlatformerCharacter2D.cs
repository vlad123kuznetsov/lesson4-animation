using System;
using Standard_Assets._2D.Scripts;
using UnityEngine;

namespace Lesson4
{
    public class PlatformerCharacter2D : BasePlatformerCharacter2D
    {
        [SerializeField] private float maxSpeed = 10f;                   
        [SerializeField] private float jumpForce = 400f;                
        [Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;  
        [SerializeField] private bool airControl = false;
        [SerializeField] private LayerMask whatIsGround;           

        private Transform groundCheck; 
        const float groundRadius = .2f; 
        private bool grounded;
        private Animator animator;    
        private Rigidbody2D rigidBody;
        private bool facingRight = true; 

        private void Awake()
        {
            groundCheck = transform.Find("GroundCheck");
            animator = GetComponent<Animator>();
            rigidBody = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            grounded = false;

            var colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, whatIsGround);
            foreach (var t in colliders)
            {
                if (t.gameObject != gameObject)
                    grounded = true;
            }
            animator.SetBool("Ground", grounded);
            animator.SetFloat("vSpeed", rigidBody.velocity.y);
        }


        public override void Move(float move, bool crouch, bool jump)
        {
            // Set whether or not the character is crouching in the animator
            animator.SetBool("Crouch", crouch);

            if (grounded || airControl)
            {
                move = (crouch ? move*crouchSpeed : move);

                animator.SetFloat("Speed", Mathf.Abs(move));

                rigidBody.velocity = new Vector2(move * maxSpeed, rigidBody.velocity.y);

                if (move > 0 && !facingRight)
                {
                    Flip();
                }
                else if (move < 0 && facingRight)
                {
                    Flip();
                }
            }
            
            if (grounded && jump && animator.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                grounded = false;
                animator.SetBool("Ground", false);
                rigidBody.AddForce(new Vector2(0f, jumpForce));
            }
        }


        private void Flip()
        {
            facingRight = !facingRight;
            var theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
