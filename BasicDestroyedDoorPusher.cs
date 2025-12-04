using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDestroyedDoorPusher : MonoBehaviour
{
    [SerializeField]
    private  float pushPower = 5f;
    [SerializeField]
    private Vector3 pushDirection = Vector3.right;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found!");

           // enabled = false; // Disable the script if there's no Rigidbody
        }
        ApplyPush();
        
    }

    private void ApplyPush()
    {
        if (rb != null)
        {
            rb.AddForce(pushDirection * pushPower, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
