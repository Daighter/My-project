using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject gameObject;
    // Update is called once per frame
    void Update()
    {
        gameObject.AddComponent<AudioSource>();
    }
}
