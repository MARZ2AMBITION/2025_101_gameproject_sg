using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaxisMover : MonoBehaviour  //
{
    public float speed =5.0f;
    public float timer = 5.0f;

    // Update is called once per frame
    void Update()
    { // z축방향으로 이동
        transform.Translate(0, 0, speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
