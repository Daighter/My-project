using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TankFire230518 : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePosition;
    private bool isPress;
    private bool reload = true;

    public UnityEvent OnFired; 

    private void Update()
    {
        if (isPress && reload)
            StartCoroutine(RepidFire());
    }

    public void FIre()
    {
        Instantiate(bulletPrefab, firePosition.position, transform.rotation);
        OnFired?.Invoke();
    }

    [SerializeField] float coolTime = 0.2f;

    IEnumerator RepidFire()
    {
        reload = false;
        FIre();
        yield return new WaitForSeconds(coolTime);
        reload = true;
    }

    private void OnFire(InputValue value)
    {
        FIre();
    }

    private void OnRepidFire(InputValue value)
    {
        if (value.isPressed)
            isPress = true;
        else
            isPress = false;
    }
}
