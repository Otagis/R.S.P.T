using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundManager : MonoBehaviour
{
    [SerializeField] GameObject[] piso;
    public int numeroDePiso;
    public bool ejecutado;

    void Start()
    {
        numeroDePiso = Random.Range(0, 5);
        ejecutado = true;
        piso[numeroDePiso].SetActive(false);
    }

}