using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetWindowController : MonoBehaviour
{
    public void OnReset()
    {
        //SceneManager.LoadScene( "main", LoadSceneMode.Single );
        SceneManager.LoadScene(1);
    }
  
    public void OnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
