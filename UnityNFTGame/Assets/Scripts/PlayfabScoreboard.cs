using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;


public class PlayfabScoreboard : MonoBehaviour
{
    [Header("UI")]
    public GameObject rowPrefab;
    public Transform rowsParent;
    public Button getLeaderboardButton;

    private void Start()
    {
        Button btnGetLeaderboard = getLeaderboardButton.GetComponent<Button>();
        btnGetLeaderboard.onClick.AddListener(GetLeaderboard);
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "GameScore",
            StartPosition = 0,
            MaxResultsCount = 3
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {

        foreach(Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {

            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.PlayFabId;
            texts[2].text = item.StatValue.ToString();

            Debug.Log(string.Format("PLACE: {0} | ID: {1} | VALUE: {2}",
                item.Position, item.PlayFabId, item.StatValue));

        }
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
        Debug.Log(error.GenerateErrorReport());
    }
}
