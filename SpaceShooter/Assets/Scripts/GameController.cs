using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
public GameObject[] hazards;
public GameObject player;
public Vector3 spawnValues;
public int hazardCount;
public float spawnWait;
public float startWait;
public float waveWait;
public Text scoreText;
public Text restartText;
public Text gameOverText;
public Text winText;
private int score;
private bool restart;
private bool gameOver;

void Start()
    {
gameOver = false;
restart = false;
restartText.text = "";
gameOverText.text = "";
winText.text = "";
score = 0;
UpdateScore();
        StartCoroutine(SpawnWaves());
    }

void Update ()
{
    if (Input.GetKey("escape"))
        {
            Application.Quit(); 
        }
        
    if (restart)
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            SceneManager.LoadScene("SpaceShooter");
        }
    }

}

IEnumerator SpawnWaves()
{
yield return new WaitForSeconds(startWait);
    while (true)
     {
     for (int i = 0; i < hazardCount; i++)
        {
        GameObject hazard = hazards [Random.Range (0, hazards.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(hazard, spawnPosition, spawnRotation);
        yield return new WaitForSeconds(spawnWait);
        }
     yield return new WaitForSeconds(waveWait);

     if (gameOver)
     {
         restartText.text = "Press 'Space' for Restart";
         restart = true;
         break;
     }
     }
}

public void AddScore(int newScoreValue)
{
score += newScoreValue;
UpdateScore();
}

void UpdateScore()
{
scoreText.text = "Points: " + score;
if(score >= 100)
{
    winText.text="You Win!\nGame created by\nJulia Hutchins";
    gameOver = true;
    gameOverText.text = "";
    restart = true;
    Destroy(player);
}
}
public void GameOver ()
{
    gameOverText.text = "Game Over!";
    gameOver = true;
}

}