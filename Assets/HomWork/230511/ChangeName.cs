using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeName : MonoBehaviour
{
    [SerializeField] GameObject tank;
    // Start is called before the first frame update
    void Start()
    {
        tank.name = "Player";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
