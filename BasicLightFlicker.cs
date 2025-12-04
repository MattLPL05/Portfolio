using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLightFlicker : MonoBehaviour
{

    [SerializeField]
    private float OffTime;
     [SerializeField]
    private float OnTime;
    [SerializeField]
    private GameObject Light;




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LightOn());
    }

    IEnumerator LightOn()
    {
        Light.SetActive(true);
        yield return new WaitForSeconds(OnTime);
        StartCoroutine(LightOff());
    }
     IEnumerator LightOff()
    {
        Light.SetActive(false);
        yield return new WaitForSeconds(OffTime);
        StartCoroutine(LightOn());
    }

}
