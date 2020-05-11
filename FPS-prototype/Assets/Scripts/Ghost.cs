using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameplayManager gameplayManager;
    public float speed;
    Player player;
    Vector3 movementDir = Vector3.zero;
    enum State
    { 
        erratic,
        aggressive,
    }
    State state = State.erratic;
    void Start()
    {
        player = FindObjectOfType<Player>();
        gameplayManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameplayManager>();
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
        

        if (transform.position.x < gameplayManager.xLimit1 || transform.position.x > gameplayManager.xLimit2 ||
            transform.position.z < gameplayManager.zLimit1 || transform.position.z > gameplayManager.zLimit2)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator changeDir()
    {
        while(true)
        {
            movementDir = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            movementDir.Normalize();
            yield return new WaitForSeconds(Random.Range(2, 4));
            movementDir = Vector3.zero;
            yield return new WaitForSeconds(Random.Range(0.5f, 2));
        }
    }
    void OnDestroy()
    {
        gameplayManager.ghostsAmount--;
    }
}
