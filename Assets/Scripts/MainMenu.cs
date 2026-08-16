using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    [Header("Wwise Stuff")]
    [SerializeField] AK.Wwise.Event _uiStartEvent;
    [SerializeField] AK.Wwise.Event _uiQuitEvent;
    [SerializeField] AK.Wwise.Event _mainMenuMusicStart;


    void Start()
    {
        _mainMenuMusicStart.Post(gameObject);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        playButton.onClick.AddListener(Play);
        if (quitButton != null)
            quitButton.onClick.AddListener(Quit);
    }

    void Play()
    {
        SceneManager.LoadScene("Game");
        _uiStartEvent.Post(gameObject);
    }

    void Quit()
    {
        _uiQuitEvent.Post(gameObject);
        Application.Quit();
    }
}
