using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuManager : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    public void PauseGame() {
        if(isPaused) {
            Resume();
        }
        else {
            Pause();
        }
        
    }

    private void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        Player.instance.enabled = false;
        Player.instance.DisablePlayerInput();
        PlayerMovement.instance.enabled = false;
        Shooting.instance.DisableShooting();
        EventSystemManager.instance.SwitchFirstSelected(isPaused);
    }

    private void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Player.instance.enabled = false;
        Player.instance.EnablePlayerInput();
        PlayerMovement.instance.enabled = true;
        Shooting.instance.EnableShooting();
        EventSystemManager.instance.SwitchFirstSelected(isPaused);
    }

    public void ResumeButton() {
        Resume();
    }

    public void SettingsButton() {

    }

    public void MainMenuButton() {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        GameManager.instance.RemoveFromDontDestroyOnLoad();
    }
}
