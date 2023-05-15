using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TankMove : MonoBehaviour
{
    Vector3 dir;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float rotSpeed = 300;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * dir.z * moveSpeed * Time.deltaTime, Space.Self);
    }

    private void OnMove(InputValue value)
    {
        dir.z = value.Get<Vector2>().y;
        dir.x = value.Get<Vector2>().x;
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, dir.x * rotSpeed * Time.deltaTime);
    }
}
