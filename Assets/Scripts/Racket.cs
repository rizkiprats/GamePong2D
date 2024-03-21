using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;

    public string axis = "Vertical";
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Buat disable Player2 input saat bermain singleplayer
        if (axis == "Vertical2" && GameData.instance.isSingePlayer)
        {
            return;
        }

        //mengambil Variable dari setting unity input dan output(-1,1)
        float v = Input.GetAxis(axis);
        rb.velocity = new Vector2(0, v) * speed;

        //Agar Tidak Keluar Batas Atas
        if (transform.position.y > 2f)
        {
            transform.position = new Vector2(transform.position.x, 2f);
        }

        //Agar Tidak Keluar Batas Bawah
        if (transform.position.y < -2f)
        {
            transform.position = new Vector2(transform.position.x, -2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            anim.SetTrigger("Shoot");
        }
    }
}
