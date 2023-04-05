using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    [Header ("Movement")]
    public Rigidbody2D rb;
    public float movespeed;
    private float direction;
    public bool facingRight;
    public int bounceforce = 1500;
    private ToggleBlocks tb;


    [Header("Jumping")]
    private bool IsGrounded;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    public float jumpforce;
    public bool flipped = false;

    [Header("Shooting")]
    public Transform LaserSpawn;
    public GameObject LaserFab;
    public float laserSpeed;
    public float fireRate;
    float nextfire;

    [Header("Animations")]
    public Animator animator;
    public Camera camera;


    [Header("AreaShift")]
    public GameManager manager;
    private bool ioujump = true;
    public Death dead;

    [Header("Take Damage")]
    public float flashTime;
    public float flashInterval;
    public Image DamageIndicator;
    public AudioSource AudioSource;
    bool touchingspikes;


    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        facingRight = true;
        tb = GameObject.FindWithTag("toggle").GetComponent<ToggleBlocks>();

    }

    // Update is called once per frame
    void Update()
    {

        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movespeed * direction, rb.velocity.y);

        if (Mathf.Abs(direction) > 0.0001f)
            AudioSource.enabled = true;
        else
            AudioSource.enabled = false;

        animator.SetFloat("Speed", Mathf.Abs(direction));
    if(!flipped)
        {
            if (direction < 0 && facingRight)
            {
                Flip();
            }
            else if (direction > 0 && !facingRight)
            {
                Flip();
            }
        }
     else
        {
            if (direction > 0 && facingRight)
            {
                Flip();
            }
            else if (direction < 0 && !facingRight)
            {
                Flip();
            }
        }


        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.3f, GroundLayer);
        if(IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            if(flipped == false) 
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            else
                rb.velocity = new Vector2(rb.velocity.x, -jumpforce);
            animator.SetBool("IsJumping", true);
            Invoke("DoneJumping", 0.4f);
       
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            Shoot();
        }
    }




    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void Shoot()
    {
        if(Time.time > nextfire)
        {
            nextfire = Time.time + fireRate;
           GameObject laserclone = Instantiate(LaserFab, LaserSpawn.position, transform.rotation);
            if(facingRight)
                laserclone.GetComponent<Rigidbody2D>().velocity = new Vector2(laserSpeed, 0);
            else
                laserclone.GetComponent<Rigidbody2D>().velocity = new Vector2(-laserSpeed, 0);

        }

    }

  public void DoneJumping()
    {
        animator.SetBool("IsJumping", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "jumppad")
        {
            if(flipped)
                rb.AddForce(Vector2.down * bounceforce);
            else
                rb.AddForce(Vector2.up * bounceforce);
        }
            
        if(collision.collider.gameObject.tag == "deathlaser")
        {
            Debug.Log("a");
            dead.respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "redtileswitch")
        {
            tb.switchTile();
            collision.gameObject.SetActive(false);
        }
        if(collision.gameObject.tag == "JumpTrigger")
        {
            if (ioujump)
                bounceforce = 1700;
            else
                bounceforce = 1300;
            ioujump = !ioujump;
        }

        if (collision.gameObject.tag == "Spikes")
        {
            

        }

        if (collision.gameObject.tag == "Shift")
        {
            Destroy(collision.gameObject);
            manager.ShiftCamera(false);
        }
        if ((collision.gameObject.tag == "leftshift"))
        {
            Destroy(collision.gameObject);
            manager.ShiftCamera(true);
        }
            
        if(collision.gameObject.tag == "VerticalShift")
        {
            manager.VerticalShiftCamera();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    

}
 

