using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    float zLimit1 = -50f;
    float zLimit2 = 50f;
    float xLimit1 = -50f;
    float xLimit2 = 50f;

    Player player;
    public TextShowed UIText;
    public GameObject ghost;
    public GameObject bomb;
    public int ghostsAmount;
    public int bombsAmount;
    public int ghostsTargetAmount;
    public int bombsTargetAmount;

    public int healthPoints = 100;
    public int score = 0;
    
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.subtractLife = subtractLife;
        UIText.setGameplayUIText = updateUIText;
    }

    void Update()
    {
        if (healthPoints <= 0)
        {
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true;
            GameManager.Get().GameOver(0);
        }

        if (score >= 100)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameManager.Get().GameOver(1);
        }

        while (ghostsAmount < ghostsTargetAmount)
        {
            Vector3 aux;
            do
            {
                aux = new Vector3(UnityEngine.Random.Range(xLimit1, xLimit2), 2, UnityEngine.Random.Range(zLimit1, zLimit2));   
            } while (Vector3.Distance(player.transform.position,aux)<15);
            Ghost ghostTemp = Instantiate(ghost, aux, Quaternion.identity).GetComponent<Ghost>();
            ghostTemp.updateGhostAmount = decreaseGhostAmmount;
            ghostTemp.hurtPlayer = subtractLife;
            ghostTemp.zMinLimit = zLimit1;
            ghostTemp.zMaxLimit = zLimit2;
            ghostTemp.xMinLimit = xLimit1;
            ghostTemp.xMaxLimit = xLimit2;

            ghostsAmount++;
        }
        
        while (bombsAmount < bombsTargetAmount)
        {
            Vector3 aux;
            do
            {
                aux = new Vector3(UnityEngine.Random.Range(xLimit1, xLimit2), 0.5f, UnityEngine.Random.Range(zLimit1, zLimit2));
            } while (Vector3.Distance(player.transform.position, aux) < 10);
            Bomb bombTemp = Instantiate(bomb, aux, Quaternion.identity).GetComponent<Bomb>();
            bombTemp.addScore = addScore;
            bombTemp.hurtPlayer = subtractLife;
            bombTemp.updateBombAmount = decreaseBombAmmount;
            bombsAmount++;
        }
        
    }

    public void subtractLife(GameObject go)
    {
        if (go.CompareTag("Ghost"))
        {
            healthPoints -= 10;
        }
        if (go.CompareTag("Bomb"))
        {
            healthPoints -= 50;
        }
    }

    public void addScore()
    {
        score += 10;
    }

    public void decreaseBombAmmount()
    {
        bombsAmount--;
    }

    public void decreaseGhostAmmount()
    {
        ghostsAmount--;
    }

    public void updateUIText()
    {
        UIText.healthShown = healthPoints;
        UIText.scoreShown = score;
    }
}
