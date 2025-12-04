using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSceneStageDirector : MonoBehaviour
{

    [SerializeField]
    private GameObject[] SceneStates;

    private GameObject ProgressTracker;
    private int currstate;

    // Start is called before the first frame update
    void Start()
    {
        ProgressTracker = GameObject.Find("ProgressTracker"); // Gameobject holding our scenestates

        for(var i = 0; i < SceneStates.Length; i++)
        {
            SceneStates[i].SetActive(false);
        }

        currstate = ProgressTracker.GetComponent<SpecialProgressTracker>().CurrentSceneState;
        SceneStates[currstate].SetActive(true);
    }
}
