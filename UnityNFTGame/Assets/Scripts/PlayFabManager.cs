using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;


public class PlayFabManager : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;
    public Button registerButton;
    public Button loginButton;
    public Button resetPasswordButton;

    void Start()
    {
        Button btnRegister = registerButton.GetComponent<Button>();
        btnRegister.onClick.AddListener(RegisterButton);

        Button btnLogin = loginButton.GetComponent<Button>();
        btnLogin.onClick.AddListener(LoginButton);

        Button btnReset = resetPasswordButton.GetComponent<Button>();
        btnReset.onClick.AddListener(ResetPasswordButton);
    }

    public void RegisterButton()
    {
        if(passwordInput.text.Length < 6)
        {
            Debug.Log("Password too short!");
            messageText.text = "Password too short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "27C9D"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in!";
        SceneManager.LoadScene("Level1");
        Debug.Log("Registered and logged in!");
    }

    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Successfully logged in!";
        SceneManager.LoadScene("Level1");
        Debug.Log("Successfully logged in!");
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset email is sent!";
        Debug.Log("Password reset email is sent!");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
        Debug.Log(error.GenerateErrorReport());
    }
}
