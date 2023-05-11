using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartJump : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float jumpPower = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
