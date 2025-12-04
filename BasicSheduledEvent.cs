using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSheduledEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject MainObject;
    [SerializeField]
    private float Delay;

    [SerializeField]
    private bool IsPSychical;
    [SerializeField]
    private bool ReverseEffect;
    [SerializeField]
    private bool LockAfterUse;

    private bool IsLocked = false;

    
    void OnTriggerEnter(Collider other)
    {
        if(IsPSychical == true)
        {
            if(IsLocked == false)
            {
                if(LockAfterUse == true)
                {
                    MainAction();
                    IsLocked = true;
                }
                if(LockAfterUse == false)
                {
                    MainAction();
                }
            }
            
        }
    }

    private void MainAction()
    {
        StartCoroutine(Eventus());
    }


    private IEnumerator Eventus()
    {
        yield return new WaitForSeconds(Delay);
        if(ReverseEffect == true)
        {
            MainObject.SetActive(false);
        }
         if(ReverseEffect == false)
        {
            MainObject.SetActive(true);
        }
    }

}
