using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class GameScript : MonoBehaviour
{
    public GameOverScreen GameOverScreen;

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "GameScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfully leaderboard sent!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
        Debug.Log(error.GenerateErrorReport());
    }

    public void GameOver()
    {
        Debug.Log("ScoreScript.scoreValue: " + ScoreScript.scoreValue);
        GameOverScreen.Setup(ScoreScript.scoreValue);
        Debug.Log("ScoreScript.scoreValue: " + ScoreScript.scoreValue);
        SendLeaderboard(ScoreScript.scoreValue);
    }
}
