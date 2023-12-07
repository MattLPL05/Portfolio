using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimPlayer : MonoBehaviour
{

   //public Animation anim;
   [SerializeField]
   private GameObject ManualTrigger; // The object we want to play the animatio on
   [SerializeField]
   private string AnimName; // The layer and the asnimation name we want to play. Example: Base Layer.Door_open_anim
   [SerializeField]
   private bool IsPsychical; // check if under a psychical trigger
   [SerializeField]
   private bool DoesLockAfterUse;
   
   [SerializeField]
   private float StartingFrame = 0f;
   // private Collider Trigger;

   // making some private stuff to be able to use locking system and the animator
   private Animator anim;
   private bool hasBeenused;
    


    // Start is called before the first frame update
    void Start()
    {
      // anim = GetComponent<Animation>();
     // Trigger = GetComponent<BoxCollider>();
      anim = ManualTrigger.GetComponent<Animator>(); //  getting the component of the private animator above
    }

   private void OnTriggerEnter(Collider other)
    {
      if(IsPsychical == true) // checks if is psychical
      {
        if(hasBeenused == false) // checks if has been used
        {
          if(DoesLockAfterUse == true) // checks with out global bool, does lock the trigger
          {
            Animate();
            hasBeenused = true;
          }
          if(DoesLockAfterUse == false) // checks with out global bool, does not lock the trigger
          {
            Animate();
          }
        }
         
      }
      
      
      
    }

   private void Animate() //responsible for animating
    {
      if (anim != null) // makes sure that the actual animator conponent exists on the object
         {
               //Play the animation on a specific layer and at what frame it starts)
               anim.Play(AnimName, 0, StartingFrame);
         }
    }

}
