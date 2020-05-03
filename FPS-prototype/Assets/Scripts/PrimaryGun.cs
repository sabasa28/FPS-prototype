using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryGun : MonoBehaviour
{
    public float rayDistance = 10;
    AudioSource gunfire;
    Animation recoil;
    void Start()
    {
        gunfire = GetComponent<AudioSource>();
        recoil = GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gunfire.Play();
            recoil.Play("GunShot");
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

            if (Input.GetKeyDown(KeyCode.Mouse0)&&hit.transform.gameObject.tag=="Enemy")
            {
                Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.white);
        }
    }
}