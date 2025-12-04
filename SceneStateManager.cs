using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStateManager : MonoBehaviour
{
    [SerializeField]
    private bool IsPsychical;
    [SerializeField]
    private int SetToValue;

    private GameObject ProgressTracker;

    // Start is called before the first frame update
    void Start()
    {
        ProgressTracker = GameObject.Find("ProgressTracker"); //get the scene state holding Gameobject

        //ProgressTracker.GetComponent<SpecialProgressTracker>().CurrentSceneState
    }

    private void OnTriggerEnter(Collider other)
    {
        if(IsPsychical == true)
        {
           ChangeSceneState();
        }
    }

    private void ChangeSceneState()
    {
        ProgressTracker.GetComponent<SpecialProgressTracker>().CurrentSceneState = SetToValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
