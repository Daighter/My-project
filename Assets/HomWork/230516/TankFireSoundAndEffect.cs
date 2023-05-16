using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankFireSoundAndEffect : MonoBehaviour
{
    [SerializeField] GameObject player;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = player.GetComponent<AudioSource>();
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
        Instantiate(bullet, firePosition.position, transform.rotation);
        audioSource.Play();
    }

    [SerializeField] float repeatTime = 0.2f;
    private Coroutine BulletRoutine;
    private bool IsPress = false;
    private bool coolTime = true;
    IEnumerator BulletMakeRoutine()
    {
        Instantiate(bullet, firePosition.position, transform.rotation);
        yield return new WaitForSeconds(repeatTime);
        coolTime = true;
    }

    private void OnRepidFire(InputValue value)
    {
        if (value.isPressed)
            IsPress = true;
        else
            IsPress = false;
    }
}
