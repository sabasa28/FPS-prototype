using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SecondaryGun : MonoBehaviour
{
    public GameObject bullet;
    AudioSource gunfire;
    Animation recoil;
    Quaternion origRot;
    bool AbleToShoot = true;
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
        if (Input.GetKeyDown(KeyCode.Mouse0)&&AbleToShoot)
        {
            gunfire.Play();
            recoil.Play("GunShot");
            GameObject goTemp=Instantiate(bullet, transform.position, transform.rotation);
            StartCoroutine(timeBetweenShots());
        }
    }
    IEnumerator timeBetweenShots()
    {
        AbleToShoot = false;
        yield return new WaitForSeconds(0.2f);
        AbleToShoot = true;
    }
}
