using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameManager gamemanager;
    public float speed;
    Vector3 movementDir = new Vector3(0,0,0);
    void Start()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        StartCoroutine(changeDir());
    }

    private void Update()
    {
        transform.position += movementDir*Time.deltaTime *speed;
        transform.rotation = Quaternion.LookRotation(movementDir);

        if (transform.position.x < gamemanager.xLimit1 || transform.position.x > gamemanager.xLimit2 ||
            transform.position.z < gamemanager.zLimit1 || transform.position.z > gamemanager.zLimit2)
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
            yield return new WaitForSeconds(5);
        }
    }
    void OnDestroy()
    {
        gamemanager.ghostsAmount--;
    }
}
