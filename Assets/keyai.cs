using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyai : MonoBehaviour
{
    public AIPath path;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            path.enabled = true;
        }
    }
}
