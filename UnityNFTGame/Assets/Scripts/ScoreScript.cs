using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    TMP_Text score;
    public GameObject GameManager;
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
        if(scoreValue >= 10)
        {
            GameManager.GetComponent<GameScript>().GameOver();
            this.enabled = false;
            scoreValue = 0;
        }
        if(playerHealth.currentHealth <= 0)
        {
            GameManager.GetComponent<GameScript>().GameOver();
            this.enabled = false;
            scoreValue = 0;
        }
    }
}
