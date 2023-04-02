using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public  class Button : MonoBehaviour
{
    public GameObject ToggleOffMap;
    public GameObject ToggleOnMap;
    public Sprite TurnedOnSprite;
    bool TurnedOn;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = TurnedOnSprite;
            if(ToggleOffMap != null)
                ToggleOffMap.GetComponent<ToggleBlocks>().switchTile();
            if(ToggleOnMap != null)
                ToggleOnMap.GetComponent<ToggleBlocks>().switchTile();
            
        }
    }
   

}
