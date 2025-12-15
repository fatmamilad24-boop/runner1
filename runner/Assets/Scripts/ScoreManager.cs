using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    private GUIStyle scoreStyle;
    private GUIStyle timerStyle;
    private int score = 0;
    private float timeElapsed = 0f;
    private bool isTimerRunning = true;
    private bool stylesCreated = false;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        if (isTimerRunning)
        {
            timeElapsed += Time.deltaTime;
        }
    }
    
    void OnGUI()
    {
        // Create styles only when OnGUI is called
        if (!stylesCreated)
        {
            CreateGUIStyles();
            stylesCreated = true;
        }
        
        // Create a background box for the game stats
        Rect boxRect = new Rect(Screen.width - 260, 20, 240, 100);
        
        // Draw semi-transparent black background
        Color originalColor = GUI.color;
        GUI.color = new Color(0, 0, 0, 0.7f);
        GUI.Box(boxRect, "");
        GUI.color = originalColor;
        
        // Display Score (inside the box)
        GUI.Label(new Rect(Screen.width - 250, 40, 220, 40), "SCORE: " + score, scoreStyle);
        
        // Display Timer (inside the box)
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        string timeString = string.Format("TIME: {0:00}:{1:00}", minutes, seconds);
        GUI.Label(new Rect(Screen.width - 250, 70, 220, 40), timeString, timerStyle);
        
        // Draw border around the box
        GUI.color = Color.yellow;
        GUI.Box(new Rect(Screen.width - 262, 18, 244, 104), "");
        GUI.color = originalColor;
    }
    
    private void CreateGUIStyles()
    {
        // Score style
        scoreStyle = new GUIStyle();
        scoreStyle.normal.textColor = Color.yellow;
        scoreStyle.fontSize = 28;
        scoreStyle.fontStyle = FontStyle.Bold;
        scoreStyle.alignment = TextAnchor.UpperLeft;
        
        // Timer style
        timerStyle = new GUIStyle();
        timerStyle.normal.textColor = Color.cyan;
        timerStyle.fontSize = 28;
        timerStyle.fontStyle = FontStyle.Bold;
        timerStyle.alignment = TextAnchor.UpperLeft;
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
    
    public int GetScore()
    {
        return score;
    }
    
    public float GetTime()
    {
        return timeElapsed;
    }
}