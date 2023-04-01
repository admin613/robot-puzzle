using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GetKey : MonoBehaviour
{
    public AIDestinationSetter Destination;
    public Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       
        if (collision.gameObject.tag == "key")
        {
            Destination.target = trans;
            StartCoroutine(fade(collision.gameObject));
            
        }

    }
    IEnumerator fade(GameObject a)
    {
        yield return new WaitForSeconds(1f);
        a.SetActive(false);
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<TilemapCollider2D>().enabled = false;
        gameObject.GetComponent<Tilemap>().color = new Color(255, 255, 255, 0.3f);
    }
}
