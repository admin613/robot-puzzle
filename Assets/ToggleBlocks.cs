using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class ToggleBlocks : MonoBehaviour
{
    public bool Toggle = false;
    public Tilemap tilemap;
    private TilemapCollider2D tp;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        tp = GetComponent<TilemapCollider2D>();
        switchTile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchTile()
    {
        Toggle = !Toggle;
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (position != null)
            {
                tilemap.RemoveTileFlags(position, TileFlags.LockColor);
                if (Toggle == true)
                {
                    tp.enabled = true;
                    tilemap.SetColor(position, new Color(255, 0, 0,255));
                   
                }
                else
                { 
                    tp.enabled = false;
                    tilemap.SetColor(position, new Color(255, 0, 0, 0.3f));
                    
                }
                    
            }
        }
    }
}
