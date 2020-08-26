using UnityEngine;

public class FPS : MonoBehaviour
{
    public static FPS framesPerSecond;
    public int frameRate;

    void Awake()
    {
        frameRate = 120;
        QualitySettings.vSyncCount = 0;
    }

    private void Start()
    {
        if (framesPerSecond == null) {
            DontDestroyOnLoad(gameObject);
            framesPerSecond = this;
        } else if (framesPerSecond != this) {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (frameRate != Application.targetFrameRate) {
            Application.targetFrameRate = frameRate;
        }
    }
}
