using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSoundAndEffect : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;
    [SerializeField] float speed = 5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 5f);
    }

    [SerializeField] private GameObject ExplosionEffect;
    private void OnCollisionEnter(Collision collision)
    {
        //audioSource.Play();
        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }
}
