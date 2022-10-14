using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int life;

    private bool isGrounded;
    private bool recovery;
    private Vector2 direction;

    private SpriteRenderer sprite;
    private Rigidbody2D rig;
    private Animator animator;
  

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        Jump();
        PlayerAnimations();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        rig.velocity = new Vector2(direction.x * speed, rig.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetInteger("Transition", 2);
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void Death()
    {

    }

    // Animations
    private void PlayerAnimations()
    {
        if (isGrounded)
        {
            if (direction.x > 0)
            {
                animator.SetInteger("Transition", 1);
                transform.eulerAngles = Vector2.zero;
            }

            if (direction.x < 0)
            {
                animator.SetInteger("Transition", 1);
                transform.eulerAngles = new Vector2(0, 180);
            }

            if (direction.x == 0)
            {
                animator.SetInteger("Transition", 0);
            }
        }
    }

    public void Hit()
    {
        
        if (!recovery)
        {
            StartCoroutine(Flick());
        }    
    }

    IEnumerator Flick()
    {
        recovery = true;
        sprite.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.3f);
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.3f);
        sprite.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.3f);
        sprite.color = new Color(1, 1, 1, 1);
        life--;
        recovery = false;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }
}
