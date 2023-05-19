using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class bulletMove230518 : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float speed = 5f;

    public UnityEvent OnCollision;

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
        OnCollision?.Invoke();
        Destroy(gameObject, 0.1f);
    }
}
