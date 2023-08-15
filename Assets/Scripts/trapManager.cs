using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapManager : MonoBehaviour
{
    [SerializeField] GameObject[] trampa;
    int numeroDeTrampa;
    int numeroRepetido;
    public int cantDeTramapasTotal = 2;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cantDeTramapasTotal; i++)
        {
            numeroDeTrampa = numeroRepetido;
            while (numeroDeTrampa == numeroRepetido)
            {
                numeroDeTrampa = Random.Range(0, 5);
            }
            trampa[numeroDeTrampa].SetActive(true);
        }
    }
}
