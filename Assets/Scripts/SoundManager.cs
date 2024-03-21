using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static SoundManager instance;
    public AudioClip uiButton;
    public AudioClip ballBounce;
    public AudioClip goal;
    public AudioClip gameOver;
    public AudioClip powerUp;

    private AudioSource audio;

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

        audio = GetComponent<AudioSource>();

    }
    public void UIClickSfx()
    {
        audio.PlayOneShot(uiButton);
    }

    public void BallBounceSfx()
    {
        audio.PlayOneShot(ballBounce);
    }

    public void GoalSfx()
    {

        audio.PlayOneShot(goal);
    }

    public void GameOverSfx()
    {
        audio.PlayOneShot(gameOver);
    }

    public void PowerUpSfx()
    {
        audio.PlayOneShot(powerUp);
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
