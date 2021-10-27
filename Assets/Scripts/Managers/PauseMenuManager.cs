using UnityEngine.SceneManagement;
using UnityEngine;

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
        EventSystemManager.instance.SwitchFirstSelected(isPaused);
    }

    private void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    private void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
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
