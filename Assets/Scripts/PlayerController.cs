using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private LayerMask m_platformMask;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;

    public float m_moveSpeed;
    public float m_jumpVelocity;

    public bool m_isMovingRight, m_isMoving, m_isJumping;

    public bool m_dies = false;

    //Se to true if we want to test on PC
    public bool m_isTestingOnPC;

    Animator m_animator;
    CollisionDetection m_collisionDetection;

    public string m_movement;

    public Transform m_initialPosition;

    private void Awake()
    {
        transform.position = m_initialPosition.position;
        m_animator = GetComponent<Animator>();
        m_animator.enabled = true;
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        m_collisionDetection = GetComponentInChildren<CollisionDetection>();   
    }

    private void OnEnable()
    {
        transform.position = m_initialPosition.position;
    }


    private void FixedUpdate()
    {
        if (m_isMoving)
        {
            if (m_isMovingRight)
            {
                rb.velocity = new Vector2(+m_moveSpeed, rb.velocity.y);
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                rb.velocity = new Vector2(-m_moveSpeed, rb.velocity.y);
                transform.eulerAngles = new Vector2(0, 180);
            }
        } // checking if playeris on the ground and the jump button had been pressed
        if (IsOnGround() && m_isJumping)
        {
            rb.velocity = Vector2.up * m_jumpVelocity;


        } //set to idle when no keys are played
        else if (IsOnGround() && !m_isJumping && !m_isMoving)
        {
            m_animator.Play("Idle");
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else if(!IsOnGround() && m_isJumping)
        {
            m_isJumping = false;
        }

        if (m_isTestingOnPC)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                m_isMoving = true;
                m_isMovingRight = false;
                m_animator.SetBool("IsWalking", true);
            }
            else
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    m_isMoving = true;
                    m_isMovingRight = true;
                    m_animator.SetBool("IsWalking", true);
                }
            }
            if (IsOnGround() && Input.GetKeyDown(KeyCode.Space))
            {
                m_isJumping = true;
                m_animator.Play("Jump");
            }
        }
    }

    private void Update()
    {
        //use keyboard
       
    }

    //this is called when the buttons are pressed the string keeps track of the button pressed
    public void MovementDetection(string movement)
    {

        if (movement == "Right")
        {
            m_isMoving = true;
            m_isMovingRight = true;
            m_animator.SetBool("IsWalking", true);
        }
        else if (movement == "Left")
        {
            m_isMoving = true;
            m_isMovingRight = false;
            m_animator.SetBool("IsWalking", true);

        }
        else if (movement == "Jump")
        {
            if(m_isJumping == false)
            {
                m_isJumping = true;
                m_animator.Play("Jump");
            }

        }
        else if (movement == "None")
        {       
            m_isMoving = false;
            m_animator.SetBool("IsWalking", false);
        }
        else if (movement == "JumpDown")
        {
            m_isJumping = false;
        }
    }

    private bool IsOnGround()
    {
        float extraHeightText = 1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, m_platformMask);
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }

}
