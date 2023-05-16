using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    [SerializeField] float playerSpeed = 5f;
    Vector3 dir;
    [SerializeField] float jumpPower = 10;
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            dir = Vector3.forward * v + Vector3.right * h;
            dir.Normalize();

            this.transform.position += dir * playerSpeed * Time.deltaTime;
            transform.forward = dir;
        }

        Vector3 pos = transform.position;
        if (pos.y <= 0.5)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("����Ű ����");
                rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }
}
