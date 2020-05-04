using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsManager : MonoBehaviour
{
    GameObject primaryGun;
    GameObject secondaryGun;
    enum Guns { 
       primary,
       secondary
    }
    Guns activeGun = Guns.primary;

    void Start()
    {
        primaryGun = transform.GetChild(0).gameObject;
        secondaryGun = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeGun = Guns.primary;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeGun = Guns.secondary;
        }
        switch (activeGun)
        {
            case Guns.primary:
                secondaryGun.SetActive(false);
                primaryGun.SetActive(true);
                break;
            case Guns.secondary:
                primaryGun.SetActive(false);
                secondaryGun.SetActive(true);
                break;
        }
    }
}
