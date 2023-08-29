using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagChanger : MonoBehaviour
{
    public GameObject[] Flags;
    private int flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = Random.Range(0, 2);
        Flags[flag].SetActive(true);
    }
}
