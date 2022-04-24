using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScript : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public void GameOver()
    {
        GameOverScreen.Setup(ScoreScript.scoreValue);
    }
}
