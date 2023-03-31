using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera camera;
    public float xShift;
    public GameObject areashift;
    public GameObject blocker;
    private bool shift = false;
    public float speed = 1.0f;
    private Vector3 targetpos;

   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(shift)
        {
            camera.transform.position = Vector3.MoveTowards(camera.transform.position, targetpos, speed * Time.deltaTime);
        }
        if (Vector3.Distance(targetpos, camera.transform.position) < 0.001f)
        {

            camera.transform.position = targetpos;
            shift = false;
        }
    }


    public void ShiftCamera()
    {
        blocker.GetComponent<BoxCollider2D>().isTrigger = false;
        Destroy(areashift, 0.1f);
        targetpos = new Vector3(camera.transform.position.x + xShift, camera.transform.position.y, -10);
        shift = true;
    }



    

}
