using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeshift : MonoBehaviour
{
    public int newyshift;
    public int newxshift;
    public GameManager gameManager;
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
        gameManager.yShift = newyshift;
        gameManager.xShift = newxshift;
    }
}
