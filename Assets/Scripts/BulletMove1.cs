using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove1 : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float speed = 5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 5f);
    }

    [SerializeField] private GameObject ExplosionEffect;
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
