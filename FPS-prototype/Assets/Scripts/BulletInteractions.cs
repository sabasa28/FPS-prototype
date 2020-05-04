using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInteractions : MonoBehaviour
{
    Rigidbody rb;
    public float shotForce;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shotForce);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        { 
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

}
