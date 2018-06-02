using Lesson4;
using UnityEngine;

namespace Standard_Assets._2D.Scripts
{
    public class SimpleCharacter2D : BasePlatformerCharacter2D
    {
        [SerializeField] private float maxSpeed = 10f;                  
        [SerializeField] private LayerMask whatIsGround;

        private Transform m_GroundCheck; 
        const float groundedRadius = .2f;
        private bool grounded; 
        private Animator animator;          
        private Rigidbody2D rigidBody;
        private bool facingRight = true;

        private void Awake()
        {
            m_GroundCheck = transform.Find("GroundCheck");
            animator = GetComponent<Animator>();
            rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            grounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, groundedRadius, whatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    grounded = true;
            }
            animator.SetBool("Ground", grounded);
            animator.SetFloat("vSpeed", rigidBody.velocity.y);
        }
        
        public override void Move(float move, bool crouch, bool jump)
        {
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


        private void Flip()
        {
            facingRight = !facingRight;
            var theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}