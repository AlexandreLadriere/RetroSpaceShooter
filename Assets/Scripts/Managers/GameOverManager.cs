using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayerDied() {
        gameOverUI.SetActive(true);
    }

    public void RetryButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(true);
        GameManager.instance.RemoveFromDontDestroyOnLoad();
    }

    public void MainMenuButton() {

    }

    public void QuitButton() {
        Application.Quit();
    }
}