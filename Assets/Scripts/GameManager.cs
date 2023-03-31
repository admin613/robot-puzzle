using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera camera;
    public float xShift;
    public GameObject areashift;
    public GameObject blocker;
   

   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShiftCamera()
    {
       camera.transform.position = new Vector3(camera.transform.position.x + xShift, 0, -10);
        blocker.GetComponent<BoxCollider2D>().isTrigger = false;
        Destroy(areashift, 0.1f);
    }

   

}
