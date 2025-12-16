using UnityEngine;
using UnityEngine.SceneManagement;

public class CodeMenu : MonoBehaviour
{
    public Rigidbody playerRigidbody; // Assign the player's Rigidbody
    private bool showMenu = true;
    private bool isPaused = true;

    void Start()
    {
        // Pause game at start
        Time.timeScale = 0f;
    }

    void Update()
    {
        // If player stops moving, show menu
        if (!isPaused && playerRigidbody.linearVelocity.magnitude < 0.01f)
        {
            ShowMenu();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Show menu on collision
        ShowMenu();
    }

    void OnGUI()
    {
        if (!showMenu) return;

        GUI.skin.button.fontSize = 20;
        int btnWidth = 200;
        int btnHeight = 50;
        int centerX = Screen.width / 2 - btnWidth / 2;
        int startY = Screen.height / 2 - 100;

        if (GUI.Button(new Rect(centerX, startY, btnWidth, btnHeight), "Play / Resume"))
        {
            ResumeGame();
        }

        if (GUI.Button(new Rect(centerX, startY + 60, btnWidth, btnHeight), "Replay"))
        {
            ReplayGame();
        }

        if (GUI.Button(new Rect(centerX, startY + 120, btnWidth, btnHeight), "Quit"))
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
