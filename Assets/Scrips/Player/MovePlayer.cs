using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public SpriteRenderer sprite;
    private BoxCollider2D coll;
    public static Vector2 LastCheckPoint = new Vector2(-10, 1);
    public LayerMask jumableground;
    public float directionX;
    public float moveSpeed;
    public float hightJump;
    bool doubleJump;
    bool Isground;

    public GameObject BulletRight;
    public GameObject Bulletleft;
    public Transform FirepointLeft;
    public Transform FirepointRight;
    public float Firerate=0.02f;
    [SerializeField] private AudioSource BulletEffect;


    private enum MovementState {idle,running,jumping,falling}
    [SerializeField] private AudioSource jumpsoundeffect;
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = LastCheckPoint;
    }
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        anim = transform.GetComponent<Animator>();
        sprite = transform.GetComponent<SpriteRenderer>();
        coll=transform.GetComponent<BoxCollider2D>();   
    }
    private void Update()
    {
        this.isGround();
        directionX = Input.GetAxisRaw("Horizontal");
        //cho nó v? v?n t?c c?a khung hình tr??c
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);

        // funtion GetButtonDown nh?y m?t l?n ko ?n gi? ???c và nó ch?a GetKeybutton
        if (Isground)
        {
            doubleJump = true;  
        }
        if (Input.GetButtonDown("Jump") && Isground)
        {
            jumpsoundeffect.Play();
            //chúng ta l?y v? trí c?a khung hình tr??c tr?c X thay vì reset nó b?ng 0
            this.rb.velocity = new Vector2(rb.velocity.x, this.hightJump);
        }
        
        if (Input.GetButtonDown("Jump") && Isground == false  && doubleJump == true)
        {
            jumpsoundeffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, this.hightJump);
            doubleJump= false;
        }
        updateanimationState();
       // shooting();
    }
    private void updateanimationState()
    {
        MovementState state;
        if (directionX > 0)
        {
            state = MovementState.running;
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
            //anim.SetBool("running", true);
           // sprite.flipX = false;
        }
        else if (directionX < 0)
        {
            state = MovementState.running;
            //anim.SetBool("running", true);
            // sprite.flipX=true;
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }
        else
        {
            state = MovementState.idle;
            //anim.SetBool("running", false);
        }
        if(rb.velocity.y > 0)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < 0)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("State",(int)state);
    }
    private bool isGround()
    {
       return Isground = Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,0.1f, jumableground);
    }
    //void shooting()
    //{
    //    if (Input.GetButtonDown("Fire1") && sprite.flipX == false&&Time.time>nextFire)
    //    {

    //        nextFire = Time.time + Firerate;
    //        Instantiate(BulletRight, FirepointRight.position, Quaternion.identity);
    //        BulletEffect.Play();
    //    }
    //    else if (Input.GetButtonDown("Fire1")&&Time.time>nextFire)
    //    {
    //        nextFire = Time.time + Firerate;
    //        Instantiate(Bulletleft, FirepointLeft.position,Quaternion.identity);
    //        BulletEffect.Play();
    //    }
    //}
}
