using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float zMinLimit;
    public float zMaxLimit;
    public float xMinLimit;
    public float xMaxLimit;
 
    public float speed;
    Player player;
    Vector3 movementDir = Vector3.zero;
    enum State
    { 
        erratic,
        aggressive,
    }
    State state = State.erratic;

    public Action<GameObject> hurtPlayer;
    public Action updateGhostAmount;

    void Start()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(changeDir());
    }

    private void Update()
    {
        switch (state)
        {
            case State.aggressive:
                movementDir = player.transform.position - transform.position;
                movementDir.y = 0;
                movementDir.Normalize();
                break;
            case State.erratic:
                break;
        }
        transform.position += movementDir * Time.deltaTime * speed;
        if (movementDir != Vector3.zero) transform.rotation = Quaternion.LookRotation(movementDir);

        if (Vector3.Distance(transform.position, player.transform.position) < 15)
        {
            state = State.aggressive;
        }
        else
        {
            state = State.erratic;
        }
        

        if (transform.position.x < xMinLimit || transform.position.x > xMaxLimit ||
            transform.position.z < zMinLimit || transform.position.z > zMaxLimit)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator changeDir()
    {
        while(true)
        {
            movementDir = new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), 0, UnityEngine.Random.Range(-1.0f, 1.0f));
            movementDir.Normalize();
            yield return new WaitForSeconds(UnityEngine.Random.Range(2, 4));
            movementDir = Vector3.zero;
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 2));
        }
    }
    void OnDestroy()
    {
        updateGhostAmount();
    }
}
