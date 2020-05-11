using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    bool GhostImmunity = false;
    public Action<GameObject> subtractLife;

    private void OnTriggerStay(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Ghost") && !GhostImmunity)
        {
            subtractLife(trigger.gameObject);
            StartCoroutine(ImmunityTime());
        }
    }

    IEnumerator ImmunityTime()
    {
        GhostImmunity = true;
        yield return new WaitForSeconds(1);
        GhostImmunity = false;
    }
}
