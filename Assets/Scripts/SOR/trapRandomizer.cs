using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapRandomizer : MonoBehaviour
{
    public GameObject[] traps;
    public int cantTrampas;
    public float distanciaEntreTrampas;
    private Vector3 nextTrapPosition;
    private int randomIndex;
    public GameObject[] flags;
    public int flag;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < cantTrampas + 1; i++)
        {
            nextTrapPosition = new Vector3 (distanciaEntreTrampas * i, 0.5f, 0);
            if (randomIndex == 1)
            {
                randomIndex = 0;
            }
            else
            {
                randomIndex = Random.Range(0, traps.Length);
            }

            Instantiate(traps[randomIndex], nextTrapPosition, Quaternion.identity);
        }
        nextTrapPosition = new Vector3(distanciaEntreTrampas * (cantTrampas + 1), 2.5f, 0);
        Instantiate(flags[flag], nextTrapPosition, Quaternion.identity);
        /*randomIndex = Random.Range(0, traps.Length);
        Vector3 randomSpawnPositionOne = new Vector3(Random.Range(-9, 0), 0.5f, 0);
        Instantiate(traps[randomIndex], randomSpawnPositionOne, Quaternion.identity);
        if (randomIndex == 1)
        {
            randomIndex = 0;
        }
        else
        {
            randomIndex = Random.Range(0, traps.Length);
        }
        Vector3 randomSpawnPositionTwo = new Vector3(Random.Range(1, 8), 0.5f, 0);
        Instantiate(traps[randomIndex], randomSpawnPositionTwo, Quaternion.identity);

        if (randomIndex == 1)
        {
            randomIndex = 0;
        }
        else
        {
            randomIndex = Random.Range(0, traps.Length);
        }
        Vector3 randomSpawnPositionThree = new Vector3(Random.Range(10, 17), 0.5f, 0);
        Instantiate(traps[randomIndex], randomSpawnPositionThree, Quaternion.identity);*/
    }
}
