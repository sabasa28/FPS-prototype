using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public float zLimit1 = -50f;
    public float zLimit2 = 50f;
    public float xLimit1 = -50f;
    public float xLimit2 = 50f;

    public GameObject ghost;
    public GameObject bomb;
    public Transform playerT;
    public int ghostsAmount;
    public int bombsAmount;
    public int ghostsTargetAmount;
    public int bombsTargetAmount;

    void Start()
    {
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        while (ghostsAmount < ghostsTargetAmount)
        {
            Vector3 aux;
            do
            {
                aux = new Vector3(Random.Range(xLimit1, xLimit2), 2, Random.Range(zLimit1, zLimit2));   
            } while (Vector3.Distance(playerT.position,aux)<15);
            Instantiate(ghost, aux, Quaternion.identity);
            ghostsAmount++;
        }
        
        while (bombsAmount < bombsTargetAmount)
        {
            Vector3 aux;
            do
            {
                aux = new Vector3(Random.Range(xLimit1, xLimit2), 0.5f, Random.Range(zLimit1, zLimit2));
            } while (Vector3.Distance(playerT.position, aux) < 10);
            Instantiate(bomb, aux, Quaternion.identity);
            bombsAmount++;
        }
        
    }
}
