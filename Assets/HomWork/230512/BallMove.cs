using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallMove : MonoBehaviour
{
    [SerializeField] float movePower = 5;
    [SerializeField] float jumpPower = 5;
    Vector3 dir;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.AddForce(dir * movePower);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    private void OnMove(InputValue value)
    {
        dir.x = value.Get<Vector2>().x;
        dir.z = value.Get<Vector2>().y;
    }

    Vector3 pos;
    private void OnJump(InputValue value)
    {
        pos = transform.position;
        if (pos.y < 0.6)
            Jump();
    }
}
