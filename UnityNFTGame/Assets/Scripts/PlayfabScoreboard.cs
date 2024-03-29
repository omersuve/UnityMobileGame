using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayfabScoreboard : MonoBehaviour
{
    [Header("UI")]
    public GameObject rowPrefab;
    public Transform rowsParent;
    public Button getBackButton;

    string loggedInPlayfabID;

    private void Start()
    {
        Button btnGetBack = getBackButton.GetComponent<Button>();
        btnGetBack.onClick.AddListener(GetBack);
        GetLeaderboard();
        GetAccountInfo();
    }

    public void GetBack()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "GameScore",
            StartPosition = 0,
            MaxResultsCount = 8
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
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            if(item.PlayFabId == loggedInPlayfabID)
            {
                texts[0].color = Color.cyan;
                texts[1].color = Color.cyan;
                texts[2].color = Color.cyan;
            }

            Debug.Log(string.Format("PLACE: {0} | ID: {1} | VALUE: {2}",
                item.Position, item.PlayFabId, item.StatValue));

        }
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
        Debug.Log(error.GenerateErrorReport());
    }

    void GetAccountInfo()
    {
        GetAccountInfoRequest request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request, OnGetAccount, OnError);
    }


    void OnGetAccount(GetAccountInfoResult result)
    {
        loggedInPlayfabID = result.AccountInfo.PlayFabId;
    }
}
