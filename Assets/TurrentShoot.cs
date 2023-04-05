using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentShoot : MonoBehaviour
{
    public Transform LaserSpawn;
    public bool facingright;
    public bool facingupdown;
    public bool facingdown;
    public GameObject LaserFab;
    private bool cooldown = true;
    public float laserSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown)
        {
            cooldown = false;
            StartCoroutine(shoot());
        }

            
    }
    IEnumerator shoot()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject laserclone = Instantiate(LaserFab, LaserSpawn.position, transform.rotation);
        if (facingupdown)
        {
            if (facingdown)
                laserclone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
            else
                laserclone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
        }
        else
        {
            if (facingright)
                laserclone.GetComponent<Rigidbody2D>().velocity = new Vector2(laserSpeed, 0);
            else
                laserclone.GetComponent<Rigidbody2D>().velocity = new Vector2(-laserSpeed, 0);
        }
        cooldown = true;

        }
    }


