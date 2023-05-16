using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveDir;
    private Rigidbody rb;

    [SerializeField] float movePower;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float rotSpeed = 300;
    [SerializeField] float jumpPower = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Rotate();
        //LookAt();
        //rotation(); ;
    }

    private void Move()
    {
        //rb.AddForce(moveDir * movePower);
        //transform.position += moveDir * moveSpeed * Time.deltaTime;
        //transform.forward = moveDir;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, moveDir.x * rotSpeed * Time.deltaTime);
    }

    private void LookAt()
    {
        transform.LookAt(new Vector3(0, 0, 0));
    }

    private void rotation()
    {
        // transform.rotation = Quaternion.Euler(0, 90, 0);
        float step2Angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg + 270;
        Quaternion toTargetAngle = Quaternion.AngleAxis(step2Angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, toTargetAngle, rotSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    private void OnJump(InputValue value)
    {
        Vector3 pos = transform.position;
        if (pos.y <= 0.5)
        {
            Jump();
        }
    }

    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePosition;
    private void OnFire(InputValue value)
    {
        Instantiate(bullet, firePosition.position, transform.rotation);
    }

    [SerializeField] float repeatTime = 1f;
    public bool reload = true;
    private Coroutine BulletRoutine;
    IEnumerator BulletMakeRoutine()
    {
        while (true)
        {
            Instantiate(bullet, firePosition.position, transform.rotation);
            yield return new WaitForSeconds(repeatTime);
            reload = true;
        }
    }

    private void OnRepidFire(InputValue value)
    {
        if (value.isPressed && reload == true)
        {
            BulletRoutine = StartCoroutine(BulletMakeRoutine());
        }
        else
        {
            StopCoroutine(BulletRoutine);
        }
    }
}
