using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove1 : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


    }
}
