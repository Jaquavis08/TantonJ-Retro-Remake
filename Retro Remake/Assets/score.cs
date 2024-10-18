using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    
    public int currentScore;
    public TMPro.TMP_Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score: " + currentScore.ToString());

        if (CompareTag("Enemy"))
        {
            
            currentScore += 1;
            scoreText.SetText("Score: " + currentScore);
            
        }
    }
}
