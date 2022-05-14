using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameMngr : MonoBehaviour
{
    public static GameMngr Instance { get; private set; }

    public delegate void GameEvent();
    public event GameEvent OnGameEvent;
    public delegate void MenuEvent();
    public event MenuEvent OnMenuEvent;
    public delegate void PauseEvent();
    public event PauseEvent OnPauseEvent;
    public delegate void DeadEvent();
    public event DeadEvent OnDeadEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSceneChange;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChange;
    }

    private void OnSceneChange(Scene current, Scene next)
    {
        // if needed
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void InitializeGame()
    {
        if (OnGameEvent != null)
        {
            OnGameEvent();
        }
    }

    public void InitializeMenu()
    {
        if (OnMenuEvent != null)
        {
            OnMenuEvent();
        }
    }

    public void InitializePause()
    {
        if (OnPauseEvent != null)
        {
            OnPauseEvent();
        }
    }

    public void InitializeDead()
    {
        if (OnDeadEvent != null)
        {
            OnDeadEvent();
        }
    }
}
