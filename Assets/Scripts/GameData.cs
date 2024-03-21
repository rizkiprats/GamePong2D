using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update

    // variabel instance membuat sebuah kelas dapat dipanggil oleh kelas lain secara mudah
    public static GameData instance;

    public bool isSingePlayer;
    public float gameTimer;
    public float ball;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else

            instance = this;

        DontDestroyOnLoad(gameObject); //menyimpan variable walau berbeda scene
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
