using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRespawn : MonoBehaviour
{
    public GameObject respawnpoint;
    public Death d;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            d.respawnpoint = respawnpoint;
    }
   

    // Update is called once per frame
    void Update()
    {


    }
}
