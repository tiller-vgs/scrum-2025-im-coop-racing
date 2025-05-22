using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseActive = false;

    public GameObject pauseMenuObject


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseIsActive)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
        PauseIsActive = false;
    }

    void Pause()
    {
        pauseMenuObject.SetActive(true);
        Time.timeScale = 0f;
        PauseIsActive = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("1.MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }
}