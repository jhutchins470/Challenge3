using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
public GameObject[] hazards;
public Vector3 spawnValues;
public int hazardCount;
public float spawnWait;
public float startWait;
public float waveWait;
public Text scoreText;
public Text restartText;
public Text hardText;
public Text gameOverText;
public Text winText;
public AudioSource winner;
public AudioSource loser;
public AudioSource bkgdMusic;
public int score;
private bool restart;
private bool restart_hard;
private bool gameOver;

void Awake ()
{
    bkgdMusic = GetComponent<AudioSource>();
}
void Start()
    {
bkgdMusic.Play();
gameOver = false;
restart = false;
restart_hard = false;
hardText.text = "";
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
    if (restart_hard)
    {
        if (Input.GetKeyDown (KeyCode.H))
        {
            SceneManager.LoadScene("SpaceShooterHard");
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
         hardText.text = "Press 'H' for Hard Mode";
         restart_hard = true;
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

public void UpdateScore()
{
scoreText.text = "Points: " + score;
if(score >= 100)
{
    Win ();
}
}
public void GameOver ()
{
    bkgdMusic.mute = true;
    loser.Play ();
         gameOverText.text = "Game Over!";
         gameOver = true;
}
public void WinMusic ()
{
    bkgdMusic.mute = true;
    winner.Play ();
}

public void Win ()
{
    WinMusic ();
    winText.text="You Win!\nGame created by\nJulia Hutchins";
    gameOver = true;
    gameOverText.text = "";
    restart = true;
}
}