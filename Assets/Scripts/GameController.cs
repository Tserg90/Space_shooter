using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public TextMesh scoreText;
    private int score;
    private bool gameover;
    public GameObject resetWindow;
    public TextMesh finalScore;
    private void Start()
    {
        gameover = false;

        score = 0;
        UpdateScore();

        StartCoroutine( SpawnWaves() );

        ResetWindowHide();
        
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true) {

            for(int i = 0; i < hazardCount; i++ )
            {

                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), 0f);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard[Random.Range(0,2)], spawnPosition, spawnRotation);

                yield return new WaitForSeconds(Random.Range(0.5f, spawnWait));
            }

            yield return new WaitForSeconds(waveWait);

            if (gameover)
            {
                break;
            }
        }
    }
    void UpdateScore()
    {
        scoreText.text = "Score: "+score;
    }
    public void AddScore( int newValue )
    {
        score += newValue;
        UpdateScore();
    }
    public void GameOver()
    {
        ResetWindowShow();
        gameover = true;
    }
    public void ResetWindowShow()
    {
        resetWindow.gameObject.SetActive( true );
        scoreText.text = "";
        finalScore.text = "Your Score: "+score;
        DataHolder.BestScore = score;
    }
    public void ResetWindowHide()
    {
        resetWindow.gameObject.SetActive( false );
    }

}
