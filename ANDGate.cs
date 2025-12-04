using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANDGate : MonoBehaviour
{


    [SerializeField]
    private GameObject self;
    [SerializeField]
    private GameObject ToActivate;
    [SerializeField]
    private GameObject Object1;
    [SerializeField]
    private GameObject Object2;
    [SerializeField]
    private bool DisableInstead;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(Object1.activeInHierarchy == true && Object2.activeInHierarchy == true)
        {
            if(DisableInstead == true)
            {
                ToActivate.SetActive(false);
                self.SetActive(false);
            }
            if(DisableInstead == false)
            {
                ToActivate.SetActive(true);
                self.SetActive(false);
            }
            
        }
    }
}
