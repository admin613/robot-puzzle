using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBlock : MonoBehaviour
{
    public Rigidbody2D player;
    public PlayerMove pv;
    public float bounceforce = 1700f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D (Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            
                player.AddForce(Vector2.up * bounceforce);
           
        }
    }
}
