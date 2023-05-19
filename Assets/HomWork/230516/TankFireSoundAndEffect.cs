using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TankFireSoundAndEffect : MonoBehaviour
{
    public UnityEvent OnFired;

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

        GameManager.Data.AddShootCount(1);
        OnFired?.Invoke();
    }

    private void OnRepidFire(InputValue value)
    {
        if (value.isPressed)
            IsPress = true;
        else
            IsPress = false;
    }
}
