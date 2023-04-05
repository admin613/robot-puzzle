using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityswitch : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public PlayerMove pv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (pv.flipped == false && !pv.facingRight)
            {
                player.transform.eulerAngles = new Vector3(0, 0, 180f);
                pv.facingRight = !pv.facingRight;
            }
            else if(pv.flipped == false)
                player.transform.eulerAngles = new Vector3(0, 0, 180f);

            else if(!pv.facingRight)
            {
                player.transform.eulerAngles = Vector3.zero;
                pv.facingRight = !pv.facingRight;
            }
            else
                player.transform.eulerAngles = Vector3.zero;


            pv.flipped = !pv.flipped;
            rb.gravityScale *= -1;
        }
    }

}
