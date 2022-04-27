using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayfabDisplayName : MonoBehaviour
{
    public Button displayNameButton;
    public TMP_InputField nameInput;

    private void Start()
    {
        Button btnDisplayName = displayNameButton.GetComponent<Button>();
        btnDisplayName.onClick.AddListener(SubmitNameButton);
    }

    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Display name updated!");
        SceneManager.LoadScene("Menu");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
        Debug.Log(error.GenerateErrorReport());
    }
}
