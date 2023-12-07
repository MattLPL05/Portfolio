using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvideMaterials : MonoBehaviour
{
    //define the amount of material, the material itself, and if it's directly under trigger
    [SerializeField]
    private int Amount;
    [SerializeField]
    private string Material;
    [SerializeField]
    private bool IsPsychical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Provide() // main function, responsible for giving the material
    {
        //checks if the "material" string above contains the word to give the material
        if(Material.Contains("batteries"))
        {
            //Find a gameObject in a scene responsible for saving player's progress and update player's inventory so it saves beetween scenes.
            GameObject.Find("CurrentPlayerInventory").GetComponent<PlayerInventoryHandler>().Battremaining = GameObject.Find("CurrentPlayerInventory").GetComponent<PlayerInventoryHandler>().Battremaining + Amount;
           
            
            Debug.Log("batteries arrived with amount of: " + Amount);
        }
    }

     void OnTriggerEnter(Collider other)
     {
        if(IsPsychical == true)
        {
            Provide();
        }
     }

    // Update is called once per frame
    void Update()
    {
        //left empty to allow expanding the functions of the script
    }
}
