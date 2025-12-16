using UnityEngine;
using UnityEngine.SceneManagement;

public class CodeMenu : MonoBehaviour
{
    private bool showMenu = true;

    void Start()
    {
        Time.timeScale = 0f; // Pause game at start
    }

    void OnGUI()
    {
        if (!showMenu) return;

        int btnWidth = 200;
        int btnHeight = 50;
        int centerX = Screen.width / 2 - btnWidth / 2;
        int startY = Screen.height / 2 - 75;

        GUI.skin.button.fontSize = 24;

        if (GUI.Button(new Rect(centerX, startY, btnWidth, btnHeight), "Play"))
        {
            PlayGame();
        }

        if (GUI.Button(new Rect(centerX, startY + 70, btnWidth, btnHeight), "Replay"))
        {
            ReplayGame();
        }

        if (GUI.Button(new Rect(centerX, startY + 140, btnWidth, btnHeight), "Quit"))
        {
            QuitGame();
        }
    }

    private void PlayGame()
    {
        showMenu = false;
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
