using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    Vector3 prevPosition;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        prevPosition = transform.position;
    }

    float time;
    [SerializeField] float bulletSpeed = 10; 
    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        transform.LookAt(transform.position * 2 - prevPosition);
        prevPosition = transform.position;

        time += Time.deltaTime;
        if (time > 3f)
        {
            Destroy(this.gameObject);
        }
    }

    /*
    void FixedUpdate()
    {
        Vector3 deltaPos = transform.position - prevPosition;                     // ������ġ - ������ġ = ����
        float angle = Mathf.Atan2(deltaPos.y, deltaPos.z) * Mathf.Rad2Deg;// �ﰢ�Լ��� ������ ����.

        if (0 != angle)    // ��������� ������������ ���̸� ���ؼ� üũ
        {
            transform.rotation = Quaternion.Euler(angle, 0, 0);
            prevPosition = transform.position;
        }

    }*/
}
