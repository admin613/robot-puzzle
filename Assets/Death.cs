using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject Player;
    public PlayerMove pv;
    public GameObject playerprefab;
    public GameObject respawnpoint;
    public bool died = false;
    public Animator animator;
    public AudioSource deathsound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            respawn();
    }
    public void respawn()
    {
        died = true;
        deathsound.Play();
        animator.SetTrigger("death");

        Player.GetComponent<PlayerMove>().enabled = false;
        
        Player.GetComponent<Rigidbody2D>().bodyType =  RigidbodyType2D.Static;
       StartCoroutine(waiter());
      
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.45f);
        
        if(pv.flipped)
        {
            if (!pv.facingRight)
            {
                Player.transform.eulerAngles = Vector3.zero;
                pv.facingRight = !pv.facingRight;
            }
            else
                Player.transform.eulerAngles = Vector3.zero;
            pv.flipped = !pv.flipped;
            Player.GetComponent<Rigidbody2D>().gravityScale *= -1;
        }

        Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Player.GetComponent<PlayerMove>().enabled = true;
        Player.transform.position = respawnpoint.transform.position;
        animator = Player.GetComponent<Animator>();
    }
}
