using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField] GameObject[] trampa;
int numeroDeTrampa;
int cantDeTramapasTotal = 3;
public class trapManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (i = 0; i < cantDeTrampasTotal; i++)
        {
            numeroDeTrampa = Random.Range(0, 5);
            trampa[numeroDeTrampa].SetActive(true);
        }
    }
}
