using TMPro;
using UnityEngine;

public class TextSize : MonoBehaviour
{
    public TextMeshProUGUI play;
    public TextMeshProUGUI store;
    public TextMeshProUGUI settings;
    public TextMeshProUGUI leaderboard;

    float leaderboardFontSize;

    //Changes all the font sizes to the same as the biggest font size.
    private void Update()
    {
        leaderboardFontSize = leaderboard.fontSize;

        play.fontSize = leaderboardFontSize;
        store.fontSize = leaderboardFontSize;
        settings.fontSize = leaderboardFontSize;
    }
}
