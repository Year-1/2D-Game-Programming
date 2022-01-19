using TMPro;
using UnityEngine;

public class TextSizeSP : MonoBehaviour
{
    public TextMeshProUGUI timer, score;
    float textSize;

    //Changes all the font sizes to the same as the biggest font size.
    void Update()
    {
        textSize = timer.fontSize;
        score.fontSize = textSize;
    }
}
