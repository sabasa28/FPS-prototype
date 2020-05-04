using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 100;
    public int points = 0;
    bool GhostImmunity = false;

    void Update()
    {
        if (hp <= 0) 
        {
            Debug.Log("GAME OVER");
        }
        if (points >= 100) 
        {
            Debug.Log("You Win");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            hp -= 50;
            Destroy(other.gameObject);
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
            hp -= 10;
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
