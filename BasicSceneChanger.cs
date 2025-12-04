using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicSceneChanger : MonoBehaviour
{
    
    
    [Header("If scene is not specific, text is not required")]
    [SerializeField]
    private bool IsSpecific;
    [SerializeField]
    private bool IsPsychicial;
    [SerializeField]
    private string SceneName;

    //[Header]
    //If scene is not specific, text is not required
    
     void OnTriggerEnter(Collider other)
     {
        Debug.Log("Box Detected!");
        if(IsPsychicial == true)
        {
            if(IsSpecific == true)
            {
            SceneManager.LoadScene(SceneName);
            }
            else if (IsSpecific == false)
            {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
     }

    public void ChangeScene()
    {
        if(IsSpecific == true)
        {
            SceneManager.LoadScene(SceneName);
        }
        else if (IsSpecific == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

  
}
