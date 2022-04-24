using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Setup(int score)
    {
        gameObject.SetActive(true);
    }
    public void RestartButton()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Level1");
    }

    public void ExitButton()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}
