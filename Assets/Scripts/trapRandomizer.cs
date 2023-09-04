using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapRandomizer : MonoBehaviour
{
    public GameObject[] traps;
    public int cantTrampas;
    private int randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        randomIndex = Random.Range(0, traps.Length);
        Vector3 randomSpawnPositionOne = new Vector3(Random.Range(-9, 0), 0.5f, 0);
        Instantiate(traps[randomIndex], randomSpawnPositionOne, Quaternion.identity);

        randomIndex = Random.Range(0, traps.Length);
        Vector3 randomSpawnPositionTwo = new Vector3(Random.Range(1, 8), 0.5f, 0);
        Instantiate(traps[randomIndex], randomSpawnPositionTwo, Quaternion.identity);

        randomIndex = Random.Range(0, traps.Length);
        Vector3 randomSpawnPositionThree = new Vector3(Random.Range(10, 17), 0.5f, 0);
        Instantiate(traps[randomIndex], randomSpawnPositionThree, Quaternion.identity);
    }
}
