using UnityEngine;
using UnityEngine.SceneManagement;
using Timer.cs;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseActive = false; //the application will always start with this variable set as false

    public GameObject pauseMenuObject //declares which unity object is connected to this script, so the object gets turned off in unity, and vice versa.


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) //if the escape key is pressed
        {
            if (PauseIsActive) //if the static bool is true
            {
                Resume(); 
            }
            else //if the static bool is false (anything other than true)
            {
                Pause();
            }
        }
    }

    public void Resume() //the code that unpauses the application
    {
        pauseMenuObject.SetActive(false); //turns off the object(s) connected to this script when false
        TimerIsRunning == true;
        PauseIsActive = false;
    }

    void Pause() //the code that "pauses" the application
    {
        pauseMenuObject.SetActive(true); //turns on the unity objects connected to this script when true
        TimerIsRunning == false;
        PauseIsActive = true;
    }

    public void LoadMenu() //this code loads a unity scene when read
    {
        SceneManager.LoadScene("1.MainMenu"); //loads the scene that is the main menu. 
    }

    public void QuitGame() //quits the application if read
    {
        Application.Quit(); //quits the application
        Debug.Log("Quitting game"); //writes a message visible when the application is in debug
    }
}