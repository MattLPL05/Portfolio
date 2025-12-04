using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDoorOpener : MonoBehaviour
{

    [SerializeField]
    private GameObject Door1;
    [SerializeField]
    private GameObject Door2;
    [SerializeField]
    private bool IsPSychical;

    void OnTriggerEnter(Collider other)
    {
        if(IsPSychical == true)
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        Door1.SetActive(false);
        Door2.SetActive(true);
    }

}
