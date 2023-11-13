using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicador : MonoBehaviour
{
    public Transform indicadorMovement1;
    public Transform indicadorMovement2;
    public Transform indicadorMovement3;
    perillaManager indicadorPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        indicadorPosition = GameObject.Find("Script").GetComponent<perillaManager>();
    }

    // Update is called once per frame
    void Update()
    {
        indicadorMovement1.localEulerAngles = new Vector3(0, indicadorPosition.goal1, 0);
        indicadorMovement2.localEulerAngles = new Vector3(0, indicadorPosition.goal2, 0);
        indicadorMovement3.localEulerAngles = new Vector3(0, indicadorPosition.goal3, 0);
    }
}
