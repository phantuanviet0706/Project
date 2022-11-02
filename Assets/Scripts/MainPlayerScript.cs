using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerScript : MonoBehaviour
{
    private float velocity = 20;
    private float JumpHeigh = 300;
    private float DropHeight1 = 10;
    private float DropHeight2= 1.3f;



    private float Speed = 0;
    private bool OnGround = false;
    private bool DbJump = false;
    private bool TurnRight = true;
    private Rigidbody2D rigidbody2d;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Speed);
        animator.SetBool("OnGround", OnGround);
        animator.SetBool("DbJump", DbJump);
        JumpUp();
        //Vector3 position = transform.position;
        //if (position.y < -15f) GameOver(); 
    }

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float keyLeftRigth = Input.GetAxis("Horizontal");
        rigidbody2d.velocity = new Vector2(velocity*keyLeftRigth, rigidbody2d.velocity.y);
        Speed = Mathf.Abs(velocity*keyLeftRigth);
        if (keyLeftRigth > 0 && !TurnRight) CheckDirection(); 
        if (keyLeftRigth < 0 && TurnRight) CheckDirection();
    }

    void CheckDirection()
    {
        if (Speed > 5) StartCoroutine(TurnLeftRight());
        else
        {
            TurnRight = !TurnRight;
            Vector2 direction = transform.localScale;
            direction.x *= -1;
            transform.localScale = direction;
        }
        
    }

    void JumpUp()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && OnGround == true)
        {
            OnGround = false;
            rigidbody2d.AddForce((Vector2.up) * JumpHeigh);
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && OnGround == false && DbJump == false)
        {
            DbJump = true;
            rigidbody2d.AddForce((Vector2.up) * JumpHeigh * (float)1.2);
        }

        // Rơi nhanh hơn
        if (rigidbody2d.velocity.y < 0)
        {
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (DropHeight1 - 1) *Time.deltaTime;
        }else if (rigidbody2d.velocity.y>0 && !Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody2d.velocity+=Vector2.up * Physics2D.gravity.y * Time.deltaTime *(DropHeight2 - 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Untagged" || collision.tag == "Terrain")
        {
            OnGround = true;
            DbJump = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Untagged" || collision.tag == "Terrain")
        {
            OnGround = true;
            DbJump = false;
        }
    }

    IEnumerator TurnLeftRight()
    {
        yield return new WaitForSeconds(0.2f);
        TurnRight = !TurnRight;
        Vector2 direction = transform.localScale;
        direction.x *= -1;
        transform.localScale = direction;
    }

    public void GameOver()
    {
        //Destroy(gameObject);
        //print("Game Over!");
    }
}
