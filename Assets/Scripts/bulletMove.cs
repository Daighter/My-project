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
        Vector3 deltaPos = transform.position - prevPosition;                     // 현재위치 - 이전위치 = 방향
        float angle = Mathf.Atan2(deltaPos.y, deltaPos.z) * Mathf.Rad2Deg;// 삼각함수로 각도를 구함.

        if (0 != angle)    // 물리연산과 렌더링연산의 차이를 위해서 체크
        {
            transform.rotation = Quaternion.Euler(angle, 0, 0);
            prevPosition = transform.position;
        }

    }*/
}
