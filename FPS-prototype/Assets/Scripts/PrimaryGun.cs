using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryGun : MonoBehaviour
{
    public float rayDistance = 10;
    AudioSource gunfire;
    Animation recoil;
    Quaternion origRot;
    void Start()
    {
        origRot = transform.localRotation;
        gunfire = GetComponent<AudioSource>();
        recoil = GetComponent<Animation>();
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
            recoil.Play("GunShot");
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

            if (Input.GetKeyDown(KeyCode.Mouse0)&&hit.transform.gameObject.tag=="Bomb")
            {
                Destroy(hit.transform.gameObject);
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