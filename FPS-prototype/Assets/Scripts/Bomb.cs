using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Player player;
    GameObject fuse;
    MeshRenderer mRenderer;
    AudioSource []audioSource;
    AudioClip timer;
    AudioClip explotion;
    Color originalCol;
    float timeToChangeCol = 3.0f;
    int distToActivate = 5;
    public Action addScore;
    public Action <GameObject> hurtPlayer;
    public Action updateBombAmount;
    enum State
    { 
        off,
        on,
        exploded
    }
    State state = State.off;
    void Start()
    {
        player = FindObjectOfType<Player>();
        fuse = transform.GetChild(0).gameObject;
        audioSource = GetComponents<AudioSource>();
        mRenderer = GetComponent<MeshRenderer>();
        originalCol = mRenderer.material.color;
    }

    private void Update()
    {
        switch (state)
        {
            case State.off:
                if (Vector3.Distance(transform.position, player.transform.position) < distToActivate)
                {
                    StartCoroutine(Explode());
                }
                break;
            case State.on:
                break;
            case State.exploded:
                break;
        }
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
        updateBombAmount();
    }

    public IEnumerator Explode()
    {
        state = State.on;
        float t = 0.0f;
        audioSource[0].Play();
        while (mRenderer.material.color != Color.red)
        {
            t += Time.deltaTime / timeToChangeCol;
            mRenderer.material.color = Color.Lerp(originalCol, Color.red, t);
            yield return null;
        }
        audioSource[0].Stop();
        audioSource[1].Play();
        state = State.exploded;
        turnInvisible();
        yield return new WaitForSeconds(1);
        hurtPlayer(gameObject);
        Destroy(gameObject);
    }

    public void Die()
    {
        if (state != State.exploded)
        {
            addScore();
            Destroy(gameObject);
        }
    }

    void turnInvisible()
    { 
        mRenderer.enabled = false;
        fuse.SetActive(false);
    }
}
