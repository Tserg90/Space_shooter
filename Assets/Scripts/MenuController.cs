using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public TextMesh bestScore;
    private void Start()
    {
        bestScore.text = "Best Score: "+DataHolder.BestScore;
    }
    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
