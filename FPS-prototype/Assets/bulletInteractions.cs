using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletInteractions : MonoBehaviour
{
    public float shotForce;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shotForce);
    }
    
}
