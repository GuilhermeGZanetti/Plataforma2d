using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MOVEMENT_SPEED = 10.0f;
    public float JUMP_FORCE = 800f;
    public float GROUND_CHECK_RADIUS = 0.02f;
    public LayerMask jumpableLayers;
    public Transform groundDetector;
    private Rigidbody2D rb;

    private bool jumpedJustNow = false;
    private float timeJumpedJustNow=0f;
    public float MAX_TIME_BEFORE_JUMP=0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    bool IsGrounded(){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(
            groundDetector.position,
            GROUND_CHECK_RADIUS,
            jumpableLayers
        );
        return (colliders.Length > 0);
    }

    // Update is called once per frame
    void Update()
    {
        timeJumpedJustNow += Time.deltaTime;

        float vx = Input.GetAxisRaw("Horizontal") * MOVEMENT_SPEED;
        float vy = rb.velocity.y;
        rb.velocity = new Vector2(vx, vy);

        if(timeJumpedJustNow >= MAX_TIME_BEFORE_JUMP){
            jumpedJustNow = false;
        }

        if(Input.GetButtonDown("Jump")){
            jumpedJustNow = true;
            timeJumpedJustNow = 0f;
        }

        if(IsGrounded() && jumpedJustNow){
            jumpedJustNow = false;
            float vx2 = rb.velocity.x;
            float vy2 = 0.0f;
            rb.velocity = new Vector2(vx2, vy2);
            rb.AddForce(transform.up * JUMP_FORCE);
        }
    }
}
