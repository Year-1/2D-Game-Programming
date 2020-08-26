using UnityEngine;

public class GameController : MonoBehaviour
{
    public int seconds, minutes;
    public int Seconds { get { return seconds; } }
    public int Minutes { get { return minutes; } }
    public float timer;
    public UI userInterface;

    public bool gameFinished = true;
    public Vector2 finishLineSpawnPos = new Vector2(8f, -1f);
    public GameObject finishLine;

    public GameObject particles;

    bool doubleSpeed = false;

    private void Start()
    {
        userInterface.Timer(0, 0);
    }

    private void Update()
    {
        if (minutes == 1 && gameFinished) {
            Instantiate(finishLine, finishLineSpawnPos, Quaternion.identity);
            gameFinished = false;
        }

        // When the timer hits 3 minutes the game ends. Incase of error somehow glitching through the finishline.
        if (minutes == 1 && seconds == 5) {
            Time.timeScale = 0f;
            Debug.Log("Game should have ended.");
        }
        if (seconds >= 8.5f && seconds <= 9) {
            particles.SetActive(true);

        }
        if (seconds == 10) {
            Time.timeScale = 2;
            doubleSpeed = true;
        }
        if (seconds == 20) {
            Time.timeScale = 1;
            doubleSpeed = false;
            particles.SetActive(false);
        }
        if (doubleSpeed) {
            Timer(2);
        } else {
            Timer(1);
        }
    }

    // Tracks the time. Timescale sets the speed of the timer, this is for the double speed so the timer doesnt count twice as fast.
    public void Timer(int timeScale)
    {
        timer += Time.deltaTime / timeScale;
        seconds = (int)timer;
        if (seconds >= 60) {
            timer = 0;
            minutes++;
        }
        userInterface.Timer(minutes, seconds);
    }
}
