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

    Vector3 dir;
    float time;
    // Update is called once per frame
    void Update()
    {
        // rb.AddForce(Vector3.forward * 1, ForceMode.Impulse);
        dir = transform.forward;
        transform.position += dir * 10 * Time.deltaTime;

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
