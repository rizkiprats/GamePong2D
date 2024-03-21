using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Main Menu Panel List")]
    public GameObject MainPanel;
    public GameObject HowToPlayPanel;
    public GameObject TimerPanel;
    public GameObject BallPanel;



    void Start()
    {
        MainPanel.SetActive(true);
        HowToPlayPanel.SetActive(false);
        TimerPanel.SetActive(false);
        BallPanel.SetActive(false);
    }

    public void SingePlayerButton()
    {
        TimerPanel.SetActive(true);
        GameData.instance.isSingePlayer = true;
        SoundManager.instance.UIClickSfx();

    }
    public void MultiPlayerButton()
    {
        TimerPanel.SetActive(true);
        GameData.instance.isSingePlayer = false;
        SoundManager.instance.UIClickSfx();
    }
    public void BackButton()
    {
        HowToPlayPanel.SetActive(false);
        TimerPanel.SetActive(false);
        MainPanel.SetActive(true);
        BallPanel.SetActive(false);
        SoundManager.instance.UIClickSfx();
    }

    public void SetTimerButton(float Timer)
    {
        HowToPlayPanel.SetActive(false);
        TimerPanel.SetActive(false);
        MainPanel.SetActive(false);
        BallPanel.SetActive(true);
        GameData.instance.gameTimer = Timer;
        SoundManager.instance.UIClickSfx();
    }

    public void SetBall(float ball)
    {
        HowToPlayPanel.SetActive(true);
        TimerPanel.SetActive(false);
        MainPanel.SetActive(false);
        BallPanel.SetActive(false);
        GameData.instance.ball = ball;
        SoundManager.instance.UIClickSfx();
    }


    public void StartButton()
    {
        SceneManager.LoadScene("GamePlay");
        SoundManager.instance.UIClickSfx();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
