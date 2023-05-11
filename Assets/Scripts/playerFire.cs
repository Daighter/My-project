using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool Reload = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (Reload)
            {
                Reload = false;
                StartCoroutine("KeepFire");
            }
        }
    }

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject firePosition;
    [SerializeField] private float mainDelay = 0.5f;
    IEnumerator KeepFire()
    {
        GameObject bullet1 = Instantiate(bullet);
        bullet1.transform.position = firePosition.transform.position;
        bullet1.transform.rotation = firePosition.transform.rotation;
        yield return new WaitForSeconds(mainDelay);
        Reload = true;
    }
}
