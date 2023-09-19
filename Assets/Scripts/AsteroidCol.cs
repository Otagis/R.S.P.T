using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCol : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
