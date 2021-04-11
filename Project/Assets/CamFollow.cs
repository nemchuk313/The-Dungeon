using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public GameObject player; //suda wstavlaem naszego personazha

    // Update is called once per frame
    void Update()
    {
        //Camera current position
        Vector3 StartPos = transform.position;
        //Player 
        Vector3 EndPos = player.transform.position;


    }
}
