using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckIfLooked : MonoBehaviour
{

   [SerializeField]
   private Transform FirePointus;
   [SerializeField]
   private float TimedDelay = 0;
   private GameObject[] gameObjects;


   private GameObject OurHit;

    void Start()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("ReyCastDissapearenceTarget");
    }
   void Update()
   {
        ShootRay();
   }

   private void ShootRay()
   {
        RaycastHit hit;
        //Debug.DrawRay(FirePointus.position, transform.TransformDirection(Vector3.forward) * 100, Color.yellow);
        if(Physics.Raycast(FirePointus.position, transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            if(hit.transform.tag == ("ReyCastDissapearenceTarget"))
            {
                //Debug.Log("Destroyed");
                StartCoroutine(waiter());
                OurHit = hit.transform.gameObject;
                //Destroy(hit.transform.gameObject);
            }
            Debug.DrawRay(FirePointus.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            
        }
   }

private IEnumerator waiter()
{
    yield return new WaitForSeconds(TimedDelay);
    Destroy(OurHit);
}
}
