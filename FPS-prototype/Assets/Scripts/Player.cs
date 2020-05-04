using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP = 100;
    public bool GhostImmunity = false;//volver a setear private

    void Start()
    {

    }

    void Update()
    {
        if (HP<=0)
        {
            Debug.Log("GAME OVER");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Bomb")
        {
            HP -= 50;
            Destroy(hit.gameObject);
        }
    }

    private void OnTriggerStay(Collider trigger)
    {
        if (trigger.gameObject.tag == "Ghost")
        {
            HitByGhost();
        }
    }

    void HitByGhost()
    {
        if (!GhostImmunity)
        {
            HP -= 10;
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
