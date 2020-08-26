using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverMenu : MonoBehaviour
{
    public Player1 player1;
    public TextMeshProUGUI p1StatValue;
    public int p1Score;
    public Player2 player2;
    public TextMeshProUGUI p2StatValue;
    public int p2Score;
    public TextMeshProUGUI winner;

    public GameController gc;

    public GameObject nextGameButton;

    public EventSystem es;

    // Gets and sets all of the stats from the game.
    void Start()
    {
        p1Score = 0;
        p2Score = 0;

        es.SetSelectedGameObject(nextGameButton);

        if (player1 != null) {
            int mins, secs, score, coins;

            score = player1.GetScore;
            coins = player1.GetCoins;
            mins = gc.Minutes;
            secs = gc.Seconds;

            GameOver(p1StatValue, mins, secs, score, coins);

            p1Score = score;
        }
        if (player2 != null) {
            int mins, secs, score, coins;

            score = player2.GetScore;
            coins = player2.GetCoins;
            mins = gc.Minutes;
            secs = gc.Seconds;

            GameOver(p2StatValue, mins, secs, score, coins);

            p2Score = score;
        }

        if (p1Score > p2Score) {
            winner.text = "Player 1 Won";
        } else if (p2Score > p1Score) {
            winner.text = "Player 2 Won";
        } else {
            winner.text = "Tie!";
        }
    }

    // Sets the game over stats.
    void GameOver(TextMeshProUGUI statText, int mins, int secs, int score, int coins)
    {
        statText.text = "";
        statText.text += mins.ToString() + "m " + secs.ToString() + "s" + "\n";
        statText.text += score.ToString() + "\n";
        statText.text += coins.ToString() + "\n";
    }

}
