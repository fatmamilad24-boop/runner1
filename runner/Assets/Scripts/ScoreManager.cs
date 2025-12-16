using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private GUIStyle scoreStyle;
    private GUIStyle timerStyle;
    private int score = 0;
    private float timeElapsed = 0f;
    private bool isTimerRunning = true;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (isTimerRunning)
            timeElapsed += Time.deltaTime;
    }

    void OnGUI()
    {
        if (scoreStyle == null)
            CreateGUIStyles();

        // Score (top-right)
        GUI.Label(new Rect(Screen.width - 140, 10, 130, 25), "SCORE: " + score, scoreStyle);

        // Timer (under score)
        GUI.Label(new Rect(Screen.width - 140, 35, 130, 25), "TIME: " + Mathf.FloorToInt(timeElapsed), timerStyle);
    }

    void CreateGUIStyles()
    {
        scoreStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 18,
            fontStyle = FontStyle.Bold,
            normal = { textColor = Color.yellow }
        };

        timerStyle = new GUIStyle(GUI.skin.label)
        {
            fontSize = 18,
            fontStyle = FontStyle.Bold,
            normal = { textColor = Color.cyan }
        };
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public int GetScore() => score;
    public float GetTime() => timeElapsed;
}
