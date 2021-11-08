using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemManager : MonoBehaviour
{
    public static EventSystemManager instance { get; private set; }

    public EventSystem eventSystem;
    public GameObject gameOverMenuButtonFirstSelected;
    public GameObject pauseMenuButtonFirstSelected;

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

    public void SwitchFirstSelected(bool isPaused) {
        if(isPaused) {
            eventSystem.SetSelectedGameObject(pauseMenuButtonFirstSelected);
        }
        else {
            eventSystem.SetSelectedGameObject(gameOverMenuButtonFirstSelected);
        }
    }
}
