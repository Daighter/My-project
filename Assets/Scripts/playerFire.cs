using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFire : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(KeepFire());
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            StopCoroutine(KeepFire());
        }
    }

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject firePosition;
    [SerializeField] private float mainDelay = 0.5f;
    IEnumerator KeepFire()
    {
        GameObject bullet1 = Instantiate(bullet, firePosition.transform.position, transform.rotation);
        yield return new WaitForSeconds(mainDelay);
    }
}
