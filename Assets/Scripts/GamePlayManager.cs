using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;

    [Header("Game Setting")]
    public int player1Score;
    public int player2Score;
    public float timer;
    public float ball;
    public bool isOver;
    public bool goldenGoal;
    public bool isSpawnPowerUp;
    public GameObject ballSpawned;

    [Header("Prefab")]
    public GameObject BallPrefab1;
    public GameObject BallPrefab2;
    public GameObject BallPrefab3;
    public GameObject[] PowerUp;

    [Header("Panels")]
    public GameObject PausePanel;
    public GameObject GameOverPanel;

    [Header("InGame UI")]
    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI player1ScoreTxt;
    public TextMeshProUGUI player2ScoreTxt;
    public GameObject goldenGoalUI;

    [Header("GameOver UI")]
    public GameObject player1WinUI;
    public GameObject player2WinUI;
    public GameObject youWin;
    public GameObject youLose;


    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
        }

    }
    void Start()
    {

        Time.timeScale = 1;
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(false);

        player2WinUI.SetActive(false);
        player1WinUI.SetActive(false);
        youWin.SetActive(false);
        youLose.SetActive(false);

        goldenGoalUI.SetActive(false);
        ball = GameData.instance.ball;
        timer = GameData.instance.gameTimer;
        isOver = false;
        goldenGoal = false;

        SpawnBall();

    }

    public void SpawnBall()
    {
        Debug.Log("Muncul Bola"+ball);
        StartCoroutine("DelaySpawn");
    }

    private IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(3);
        if (ballSpawned == null && ball == 1)
        {
           ballSpawned = Instantiate(BallPrefab1, Vector3.zero, Quaternion.identity);
        }else if(ballSpawned == null && ball == 2)
        {
            ballSpawned = Instantiate(BallPrefab2, Vector3.zero, Quaternion.identity);
        }else if (ballSpawned == null && ball == 3)
        {
            ballSpawned = Instantiate(BallPrefab3, Vector3.zero, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        player1ScoreTxt.text = player1Score.ToString();
        player2ScoreTxt.text = player2Score.ToString();
        if (timer > 0f)
        {

            timer -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timer / 60);
            float seconds = Mathf.FloorToInt(timer % 60); //modulus
            timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (seconds % 20 == 0 && !isSpawnPowerUp)
            {
                StartCoroutine("SpawnPowerUp");
            }
        }

        if (timer <= 0f && !isOver)
        {
            timerTxt.text = "00:00";
            if (player1Score == player2Score)
            {
                if (!goldenGoal)
                {
                    goldenGoal = true;

                    Ball[] ball = FindObjectsOfType<Ball>();
                    for (int i = 0; i < ball.Length; i++)
                    {
                        Destroy(ball[i].gameObject);

                    }
                    goldenGoalUI.SetActive(true);

                    SpawnBall();

                }

            }
            else
            {
                GameOver();
            }

        }

    }

    private IEnumerator SpawnPowerUp()
    {
        isSpawnPowerUp = true;
        Debug.Log("PowerUp");
        int rand = UnityEngine.Random.Range(0, PowerUp.Length);
        Instantiate(PowerUp[rand], new Vector3(UnityEngine.Random.Range(-3.2f, 3.2f), UnityEngine.Random.Range(-2.35f, 2.25f), 0), Quaternion.identity);
        yield return new WaitForSeconds(1);
        isSpawnPowerUp = false;

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        SoundManager.instance.UIClickSfx();

    }
    public void ResumeGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        SoundManager.instance.UIClickSfx();

    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        SoundManager.instance.UIClickSfx();

    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlay");
        SoundManager.instance.UIClickSfx();
    }

    public void GameOver()
    {
        SoundManager.instance.UIClickSfx();
        isOver = true;
        Debug.Log("Game Over");
        Time.timeScale = 0;

        GameOverPanel.SetActive(true);

        if (!GameData.instance.isSingePlayer)
        {//Multiplayer
            if (player1Score > player2Score)
            {
                player1WinUI.SetActive(true);
            }
            if (player1Score < player2Score)
            {
                player2WinUI.SetActive(true);
            }
        }
        else
        {
            if (player1Score > player2Score)
            {//Singleplayer
                youWin.SetActive(true);

            }
            if (player1Score < player2Score)
            {
                youLose.SetActive(true);
            }
        }
    }
}

