using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicador : MonoBehaviour
{
    public Transform indicadorMovement;
    perillaManager indicadorPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        indicadorPosition = GameObject.Find("Script").GetComponent<perillaManager>();
    }

    // Update is called once per frame
    void Update()
    {
        indicadorMovement.localEulerAngles = new Vector3(0, indicadorPosition.goal, 0);
    }
}
