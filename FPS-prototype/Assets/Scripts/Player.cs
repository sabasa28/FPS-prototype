using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int hp = 100;
    public int points = 0;
    bool GhostImmunity = false;

    void Update()
    {
        if (hp <= 0) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(2);
        }
        if (points >= 100) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(2);
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
