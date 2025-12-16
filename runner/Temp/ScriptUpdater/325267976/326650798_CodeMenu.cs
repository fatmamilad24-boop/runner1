using UnityEngine;
using UnityEngine.SceneManagement;

public class CodeMenu : MonoBehaviour
{
    public Rigidbody playerRigidbody; // Player Rigidbody (optional)
    private bool showMenu = true;
    private bool isPaused = true;

    // Menu styling
    private GUIStyle panelStyle;
    private GUIStyle buttonStyle;
    private int btnWidth = 220;
    private int btnHeight = 60;
    private Texture2D panelTexture;

    void Start()
    {
        // Auto-assign playerRigidbody if not set
        if (playerRigidbody == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                playerRigidbody = player.GetComponent<Rigidbody>();
        }

        // Create a simple semi-transparent texture for the panel
        panelTexture = new Texture2D(1, 1);
        panelTexture.SetPixel(0, 0, new Color(0f, 0f, 0f, 0.7f));
        panelTexture.Apply();

        // Initialize panel style
        panelStyle = new GUIStyle(GUI.skin.box);
        panelStyle.normal.background = panelTexture;
        panelStyle.alignment = TextAnchor.MiddleCenter;

        // Initialize button style
        buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.fontSize = 24;
        buttonStyle.normal.textColor = Color.white;
        buttonStyle.hover.textColor = Color.yellow;
        buttonStyle.alignment = TextAnchor.MiddleCenter;

        Time.timeScale = 0f; // Pause game at start
    }

    void Update()
    {
        // If player Rigidbody exists and is almost stopped, show menu
        if (!isPaused && playerRigidbody != null && playerRigidbody.linearVelocity.magnitude < 0.01f)
        {
            ShowMenu();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Always show menu on collision
        ShowMenu();
    }

    void OnGUI()
    {
        if (!showMenu) return;

        // Draw background panel
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", panelStyle);

        // Draw buttons in the center
        int centerX = Screen.width / 2 - btnWidth / 2;
        int startY = Screen.height / 2 - 100;

        if (GUI.Button(new Rect(centerX, startY, btnWidth, btnHeight), "Play / Resume", buttonStyle))
        {
            ResumeGame();
        }

        if (GUI.Button(new Rect(centerX, startY + 80, btnWidth, btnHeight), "Replay", buttonStyle))
        {
            ReplayGame();
        }

        if (GUI.Button(new Rect(centerX, startY + 160, btnWidth, btnHeight), "Quit", buttonStyle))
        {
            QuitGame();
        }
    }

    private void ShowMenu()
    {
        showMenu = true;
        isPaused = true;
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        showMenu = false;
        isPaused = false;
        Time.timeScale = 1f;
    }

    private void ReplayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
