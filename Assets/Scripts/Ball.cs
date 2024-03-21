using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed;
    public bool isBounce;

    public bool bonusGoal;
    public bool isassHitt1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int random = Random.Range(0, 2);
        Debug.Log(random);

        if (random == 0)
        {
            rb.velocity = Vector2.right * speed;

        }
        else
        {
            rb.velocity = Vector2.left * speed;
        }
    }




    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 12 || transform.position.x < -12 || transform.position.y > 8 || transform.position.y < -8)
        {
            GamePlayManager.instance.SpawnBall();
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //float randomPos = Random.Range(-2f, 2f);

        if (col.gameObject.tag == "Racket Red" && !isBounce)
        {
            //Vector2 dir = new Vector2(1, randomPos).normalized;
            Vector2 dir = new Vector2(1, 0).normalized;
            //rb.velocity = dir * speed;
            rb.velocity = rb.velocity.normalized * speed;
            StartCoroutine("DelayBounce");
            isassHitt1 = true;
            SoundManager.instance.BallBounceSfx();
        }

        if (col.gameObject.tag == "Racket Blue" && !isBounce)
        {
            //Vector2 dir = new Vector2(-1, randomPos).normalized;
            Vector2 dir = new Vector2(-1, 0).normalized;
            //rb.velocity = dir * speed;
            rb.velocity = rb.velocity.normalized * speed;
            StartCoroutine("DelayBounce");
            isassHitt1 = true;
            SoundManager.instance.BallBounceSfx();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Goal 1")
        {
            SoundManager.instance.GoalSfx();
            GamePlayManager.instance.player2Score++;
            if (bonusGoal)
            {
                GamePlayManager.instance.player2Score++;
            }
            GamePlayManager.instance.SpawnBall();
            Destroy(gameObject);
            if (GamePlayManager.instance.goldenGoal)
            {
                GamePlayManager.instance.GameOver();
            }
        }

        if (col.gameObject.tag == "Goal 2")
        {
            SoundManager.instance.GoalSfx();
            GamePlayManager.instance.player1Score++;
            if (bonusGoal)
            {
                GamePlayManager.instance.player1Score++;
            }
            GamePlayManager.instance.SpawnBall();
            Destroy(gameObject);
            if (GamePlayManager.instance.goldenGoal)
            {
                GamePlayManager.instance.GameOver();
            }
        }

        if (col.gameObject.tag == "PowerUp")
        {
            SoundManager.instance.PowerUpSfx();
        }
    }



    private IEnumerator DelayBounce()
    {
        isBounce = true;
        yield return new WaitForSeconds(1f);
        isBounce = false;
    }

}
