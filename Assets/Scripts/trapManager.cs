using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapManager : MonoBehaviour
{
    [SerializeField] GameObject[] trampa;
    public GameObject FloorM;
    int numeroDeTrampa;
    int numeroRepetido;
    public int cantDeTramapasTotal = 2;
    // Start is called before the first frame update
    void Start()
    { //Object reference not set to an instance of an object trapManager

            
        
    }
    private void Update()
    {
        if (FloorM.GetComponent<groundManager>().ejecutado)
        {
            for (int i = 0; i < cantDeTramapasTotal; i++)
            {
                numeroRepetido = numeroDeTrampa;

                while (numeroDeTrampa == numeroRepetido)
                {
                    numeroDeTrampa = Random.Range(0, 5);
                    Comprobar();
                }

                trampa[numeroDeTrampa].SetActive(true);
                Debug.Log("número asignado");
                FloorM.GetComponent<groundManager>().ejecutado = false;
            }
        }
    }
    void Comprobar()
    {
        if (numeroDeTrampa == FloorM.GetComponent<groundManager>().numeroDePiso)
        {
            Debug.Log("Se Reinició");
            numeroDeTrampa = Random.Range(0, 5);
        }
    }
}
