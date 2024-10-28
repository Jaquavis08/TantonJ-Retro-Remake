using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.gameObject == null && player2 == null)
        {
            gameOver.SetActive(true);
            Time.timeScale = 1.0f;
            return;
        }


    }
}
