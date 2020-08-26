using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //Most of these methods close one game object and opens another.
    //The last few load a different unity scene.

    public GameObject MainMenu;
    public GameObject PlayGame;
    public GameObject Store;
    public GameObject Settings;
    public GameObject Leaderboards;

    //These are used to select a game object as focus. Allows for controller menu navigation
    public GameObject ClosePlayButton;
    public GameObject CloseStoreButton;
    public GameObject CloseSettingsButton;
    public GameObject CloseLeaderboardButton;

    public GameObject OpenPlayButton;
    //curently these default to the exit button change this in the future
    public GameObject OpenStoreButton;
    public GameObject OpenSettingsButton;
    public GameObject OpenLeaderboardButton;

    public GameObject CloseButton;

    public EventSystem es;

    public void OpenPlayGame()
    {
        MainMenu.SetActive(false);
        PlayGame.SetActive(true);
        Time.timeScale = 1;

        es.SetSelectedGameObject(OpenPlayButton);
    }

    public void ClosePlayGame()
    {
        PlayGame.SetActive(false);
        MainMenu.SetActive(true);

        es.SetSelectedGameObject(ClosePlayButton);
    }

    public void OpenStore()
    {
        MainMenu.SetActive(false);
        Store.SetActive(true);

        es.SetSelectedGameObject(OpenStoreButton);
    }

    public void CloseStore()
    {
        Store.SetActive(false);
        MainMenu.SetActive(true);

        es.SetSelectedGameObject(CloseStoreButton);
    }

    public void OpenLeaderboards()
    {
        MainMenu.SetActive(false);
        Leaderboards.SetActive(true);

        es.SetSelectedGameObject(OpenLeaderboardButton);
    }

    public void CloseLeaderboards()
    {
        Leaderboards.SetActive(false);
        MainMenu.SetActive(true);

        es.SetSelectedGameObject(CloseLeaderboardButton);
    }

    public void OpenSettings()
    {
        MainMenu.SetActive(false);
        Settings.SetActive(true);

        es.SetSelectedGameObject(OpenSettingsButton);
    }

    public void CloseSettings()
    {
        Settings.SetActive(false);
        MainMenu.SetActive(true);

        es.SetSelectedGameObject(CloseSettingsButton);
    }

    public void OpenSinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayer");
    }
    public void CloseSinglePlayer()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OpenTwoPlayer()
    {
        SceneManager.LoadScene("TwoPlayer");
    }
    public void CloseTwoPlayer()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

