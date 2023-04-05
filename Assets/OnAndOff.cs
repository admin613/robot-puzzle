using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAndOff : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite On;
    public Sprite Off;
    public bool on = true;
    public float duration =  1.0f;
    private bool startnext = true;
    private Collider2D col;
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startnext)
        {
            startnext = false;
            StartCoroutine(ONOFF());
        }
        
    }
    IEnumerator ONOFF()
    {
        
        yield return new WaitForSeconds(duration);
        if (on)
        {
            col.enabled = false;
            foreach (Transform child in transform)
            {
                child.gameObject.GetComponent<SpriteRenderer>().sprite = Off;
            }
        }
        else
        {
            col.enabled = true;
            foreach (Transform child in transform)
            {
                
                child.gameObject.GetComponent<SpriteRenderer>().sprite = On;
            }
        }
        startnext = true;
        on = !on;
       
    }
}
