using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public string namaPowerUp;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            if (namaPowerUp == "Double")
            {
                Debug.Log("BonusGoal");
                col.GetComponent<Ball>().bonusGoal = true;
            }

            if (namaPowerUp == "SpeedUp")
            {
                Debug.Log("SpeedUp");
                Ball ball = col.GetComponent<Ball>();
                ball.speed = ball.speed * 2f;
            }
            if (namaPowerUp == "ChangeDirect")
            {
                Debug.Log("ChangeDirection");
                Ball ball = col.GetComponent<Ball>();
                if (ball.isassHitt1)
                {
                    ball.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, Random.Range(-1, 1)) * ball.speed;
                }
                else
                {
                    ball.GetComponent<Rigidbody2D>().velocity = new Vector2(1, Random.Range(-1, 1)) * ball.speed;
                }
            }
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
