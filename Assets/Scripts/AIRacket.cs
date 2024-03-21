using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;

    [Header("NPC Setting")]
    public float speed;
    public float delayMode;

    private bool isMoveAI; // Checker apakah raket bergerak atau tidak
    private float randomPos;// dari -1 ke 1
    private bool isSingleTake;
    private bool isUp;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.instance.isSingePlayer)
        {

            if (!isMoveAI && !isSingleTake)
            {
                Debug.Log("kepanggil");

                StartCoroutine("DelayAIMove");
                isSingleTake = true;
            }

            if (isMoveAI)
            {
                moveAI();
            }

        }


    }

    private IEnumerator DelayAIMove()
    {
        yield return new WaitForSeconds(delayMode); //Menunggu waktu dari delayMove yang kita Setting
        randomPos = UnityEngine.Random.Range(-2f, 2f);

        if (transform.position.y < randomPos)
        {
            isUp = true;
        }
        else
        {
            isUp = false;
        }

        isSingleTake = false;
        isMoveAI = true;
    }

    private void moveAI()
    {
        // ! = invert == false
        if (!isUp)// raket ke arah bawah
        {
            rb.velocity = new Vector2(0, -1) * speed;  //velocity == Acceleration -> Vector2 X=0, Y=1
            if (transform.position.y <= randomPos) //posisi raket apakah sudah sampai diposisi random yang baru
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }

        if (isUp)
        {
            rb.velocity = new Vector2(0, 1) * speed;
            if (transform.position.y >= randomPos)
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }
    }
}
