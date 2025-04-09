using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{

    public GameObject cube;
    public int totalCube = 10;
    public float cubeSpacing = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        GenCube();
    }

    public void GenCube()
    {
        Vector3 mypositon = transform.position;

        GameObject firestCube = Instantiate(cube, mypositon, Quaternion.identity);

        for(int i=1; i<totalCube; i++)
        {
            Vector3 position = new Vector3(mypositon.x, mypositon.y, mypositon.z + (i * cubeSpacing));
            Instantiate(cube, position, Quaternion.identity);
        }
    }
}
