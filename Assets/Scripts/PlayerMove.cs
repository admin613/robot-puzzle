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
    bool facingRight;



    [Header("Jumping")]
    private bool IsGrounded;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    public float jumpforce;

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

    [Header("Take Damage")]
    public float flashTime;
    public float flashInterval;
    public Image DamageIndicator;
    bool touchingspikes;


    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        facingRight = true;

     
    }

    // Update is called once per frame
    void Update()
    {

        direction = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movespeed * direction, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(direction));

        if(direction < 0 && facingRight)
        {
            Flip();
        }
        else if (direction > 0 && !facingRight)
        {
            Flip();
        }


        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.3f, GroundLayer);
        if(IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            Debug.Log("aaa");
            touchingspikes = true;
            StartCoroutine(DamageFlash());
        }

        if (collision.gameObject.tag == "Shift")
        {
            manager.ShiftCamera();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            touchingspikes = false;
            StopCoroutine(DamageFlash());
        }
    }
    IEnumerator DamageFlash()
    {
        while (touchingspikes == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(flashTime);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(flashInterval);
        }
    }

}
 

