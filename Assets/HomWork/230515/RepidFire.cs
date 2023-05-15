using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RepidFire : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePosition;
    private void OnFire(InputValue value)
    {
        Instantiate(bullet, firePosition.position, transform.rotation);
    }

    [SerializeField] float repeatTime = 1f;
    private Coroutine BulletRoutine;
    private bool allowed = false;
    IEnumerator BulletMakeRoutine()
    {
        while (true)
        {
            if (!allowed)
                StopCoroutine(BulletRoutine);
            else
                Instantiate(bullet, firePosition.position, transform.rotation);
            yield return new WaitForSeconds(repeatTime);
        }
    }

    private void OnRepidFire(InputValue value)
    {
        if (value.isPressed)
        {
            allowed = true;
            BulletRoutine = StartCoroutine(BulletMakeRoutine());
        }
        else
        {
            allowed = false;
        }
    }
}
