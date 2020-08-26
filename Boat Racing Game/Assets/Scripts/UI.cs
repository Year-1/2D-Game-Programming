using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{
    //Game UI
    public RectTransform healthBar;
    public GameObject[] livesGO;
    public TextMeshProUGUI timerBox;
    public TextMeshProUGUI scoreBox;
    public GameObject returnMainMenu;

    public TextMeshProUGUI coins;

    public TextMeshProUGUI totalCoins;

    //Leaderboard UI
    public TextMeshProUGUI[] scores;

    EventSystem es;

    //rewards, boosts, penalty, timer?

    //Sets the values of the ui on start up.
    private void Start()
    {
        es = EventSystem.current;
    }

    //Loses the amount of lives in parameter then updates on screen.
    public void LoseLife(int lives)
    {
        for (int i = 2; i > lives - 1; i--) {
            livesGO[i].SetActive(false);
        }
    }

    //Gains a life in the parameter and then updates it on screen.
    public void GainLife(int lives)
    {
        switch (lives) {
            case 0:
                ChangeGainLife(lives);
                break;

            case 1:
                ChangeGainLife(lives);
                break;

            case 2:
                ChangeGainLife(lives);
                break;

            case 3:
                ChangeGainLife(lives);
                break;
        }
    }

    //Loops through the array and updates the life icons.
    public void ChangeGainLife(int lives)
    {
        for (int i = 0; i < lives; i++) {
            livesGO[i].SetActive(true);
        }
    }

    //Gets the health in the parameter then updates it on screen.
    public void Health(int totalHealth)
    {
        float normalisedHealth = totalHealth / 100f;
        healthBar.localScale = new Vector3(normalisedHealth, 1, 1);
    }

    //Gets the time through the parameters and then displays it on screen.
    public void Timer(int minute, int seconds)
    {
        timerBox.text = "Time: " + minute.ToString() + "m " + seconds.ToString() + "s";
    }

    //Gets the score through the parameters and displays it on screen
    public void Score(int score)
    {
        scoreBox.text = "Score: " + score.ToString();
    }

    //When the game is over, make this button appear on screen.
    public void ReturnToMainMenu()
    {
        returnMainMenu.SetActive(true);
        es.SetSelectedGameObject(returnMainMenu);
    }

    //Assigns the coins to the text.
    public void Coins(int amountOfCoins)
    {
        coins.text = "Coins: " + amountOfCoins.ToString();
    }

    //Assigns all the scores to the text objects in the game.
    public void Leaderboards()
    {
        List<int> temp = SaveLoad.SL.LeaderboardScore;

        for (int i = 0; i < 5; i++) {
            scores[i].text = temp[i].ToString();
        }
    }

    //Gets the total coins from the file and displays them on screen.
    public void TotalCoins()
    {
        int totalCoinAmount = SaveLoad.SL.TotalCoins;
        totalCoins.text = "Coins: " + totalCoinAmount.ToString();
    }
}
