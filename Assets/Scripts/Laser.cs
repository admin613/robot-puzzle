using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private ToggleBlocks tb;
    [Header("Movement")]
    public Rigidbody2D rb;
    
  
    void Start()
    {
        tb = GameObject.FindWithTag("toggle").GetComponent<ToggleBlocks>();
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Destroy(gameObject, 10f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "button")
        {
            tb.switchTile();
        }
        if(collision.gameObject.tag != "Player")
        {   
            Destroy(gameObject);
        }

    }
}
