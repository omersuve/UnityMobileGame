using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button leaderboardButton;

    private void Start()
    {
        Button btnLeaderboard = leaderboardButton.GetComponent<Button>();
        btnLeaderboard.onClick.AddListener(GoLeaderboard);
    }

    public void GoLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
