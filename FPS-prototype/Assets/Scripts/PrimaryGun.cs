using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryGun : MonoBehaviour
{
    public float rayDistance = 10;
    AudioSource gunfire;
    Animation animatation;
    Quaternion origRot;
    Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gunfire = GetComponent<AudioSource>();
        animatation = GetComponent<Animation>();
        origRot = transform.localRotation;
    }

    private void OnEnable()
    {
        transform.localRotation = origRot;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gunfire.Play();
            animatation.Play("GunShot");
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

            if (Input.GetKeyDown(KeyCode.Mouse0)&&hit.transform.gameObject.tag=="Bomb")
            {
                hit.transform.gameObject.GetComponent<Bomb>().Die();
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.white);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("AAA");
    }
}