using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundManager : MonoBehaviour
{
    [SerializeField] GameObject[] piso;
    int numeroDePiso;

    private void Start() 
    {
        numeroDePiso = Random.Range(2, 6);
        piso[numeroDePiso].SetActive(false);
    }
}