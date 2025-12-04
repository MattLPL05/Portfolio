using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeleporter : MonoBehaviour
{

    [SerializeField]
    private Transform TelPort;
     [SerializeField]
    private Transform PlayerLoc;


     void OnTriggerEnter(Collider other)
     {
        //if(other.tag == "Player")
       // {
            PlayerLoc.transform.position = TelPort.transform.position;
            Debug.Log("Player Detected in the trigger");
       // }

     }
}
