using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daniel : MonoBehaviour
{
    public GameObject hola;
    private int x;
    private int z;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            x = Random.Range(-11, 11);
            z = Random.Range(-12, 12);

            Instantiate(hola, new Vector3(x, 30, z), Quaternion.identity);
            //Instantiate(hola, new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
