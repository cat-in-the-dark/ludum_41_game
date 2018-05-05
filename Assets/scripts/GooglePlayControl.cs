using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;

public class GooglePlayControl : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        var config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        
        // silent sign in the returned user
        PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
        SignIn(); // ? do we realy need this?
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void SignIn() {
        if (!PlayGamesPlatform.Instance.localUser.authenticated) {
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
    }

    void SignInCallback(bool success)
    {
        if (success)
        {
            Debug.LogFormat("User {0} logged in.", Social.localUser.userName);
        }
        else
        {
            Debug.Log("User was not logged in.");
        }
    }

    public void ShowLeaderboards()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated) {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else {
            Debug.Log("Cannot show leaderboard: not authenticated");
        }
    }
}