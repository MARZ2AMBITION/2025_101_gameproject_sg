using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("충돌");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거작동");
    }
}
