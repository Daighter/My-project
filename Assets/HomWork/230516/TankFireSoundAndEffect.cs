using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankFireSoundAndEffect : MonoBehaviour
{
    [SerializeField] GameObject player;
    private AudioSource audioSource;
    private Animator animator;

    private void Awake()
    {
        audioSource = player.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsPress & coolTime)
        {
            coolTime = false;
            StartCoroutine(BulletMakeRoutine());
        }
    }

    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePosition;
    private void OnFire(InputValue value)
    {
        Fire();
    }

    [SerializeField] float repeatTime = 0.2f;
    private Coroutine BulletRoutine;
    private bool IsPress = false;
    private bool coolTime = true;
    IEnumerator BulletMakeRoutine()
    {
        Fire();
        yield return new WaitForSeconds(repeatTime);
        coolTime = true;
    }

    public void Fire()
    {
        Instantiate(bullet, firePosition.position, transform.rotation);
        audioSource.Play();
        animator.SetTrigger("Fire");
    }

    private void OnRepidFire(InputValue value)
    {
        if (value.isPressed)
            IsPress = true;
        else
            IsPress = false;
    }
}
