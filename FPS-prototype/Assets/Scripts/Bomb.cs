using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameManager gamemanager;

    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        gamemanager.bombsAmount--;
    }
}
