using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;

    public Rigidbody2D rb;

    [SerializeField]
    private float walkSpeed;

    public Transform groundCheckPos;
    private bool mustFlip;

    public LayerMask groundLayer;
    public Collider2D bodyCollider;

    public Animator animator;
    
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float agroRange;

    // Start is called before the first frame update
    void Start()
    {
        walkSpeed = 200f;
        mustPatrol = true;
        rb = GetComponent<Rigidbody2D>();
        agroRange = 5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer > agroRange)
        {
            if (animator != null)
                animator.SetBool("Attack", false);
            Patrol();
        }
        else if (distToPlayer <= agroRange)
        {
            if (animator != null)
                animator.SetBool("Attack", true);
            ChasePlayer();
        }
    }
    
    void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustFlip || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    private void ChasePlayer()
    {
        if (player == null)
            return;

        float direction = Mathf.Sign(player.position.x - transform.position.x);
        rb.velocity = new Vector2(direction * Mathf.Abs(walkSpeed) * 1.5f * Time.fixedDeltaTime, rb.velocity.y);

        if ((direction > 0 && walkSpeed < 0) || (direction < 0 && walkSpeed > 0))
        {
            Flip();
        }
    }

}
