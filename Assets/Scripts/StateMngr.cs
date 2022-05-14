using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class StateMngr : MonoBehaviour
{
    public static StateMngr Instance { get; private set; }

    public enum currentState
    {
        Menu,
        Game,
        Dead,
    }

    private GameMngr gameMngr;
    private Activator[] activatorList;

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

        gameMngr = FindObjectOfType<GameMngr>();
        activatorList = FindObjectsOfType<Activator>();
    }

    private void Start()
    {
        ChangeStateToMenu();
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSceneChange;

        if (gameMngr != null)
        {
            gameMngr.OnGameEvent += ChangeStateToGame;
            gameMngr.OnMenuEvent += ChangeStateToMenu;
            gameMngr.OnPauseEvent += ChangeStateToPause;
            gameMngr.OnDeadEvent += ChangeStateToDead;
        }
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChange;

        if (gameMngr != null)
        {
            gameMngr.OnGameEvent -= ChangeStateToGame;
            gameMngr.OnMenuEvent -= ChangeStateToMenu;
            gameMngr.OnPauseEvent -= ChangeStateToPause;
            gameMngr.OnDeadEvent -= ChangeStateToDead;
        }
    }

    private void OnSceneChange(Scene current, Scene next)
    {
        gameMngr = FindObjectOfType<GameMngr>();
        activatorList = FindObjectsOfType<Activator>();

        ChangeStateToMenu();
    }

    private void ChangeStateToMenu()
    {
        foreach (Activator activator in activatorList)
        {
            if (activator.menuActive)
            {
                activator.gameObject.SetActive(true);
            }
            else
            {
                activator.gameObject.SetActive(false);
            }
        }
    }

    private void ChangeStateToGame()
    {
        foreach (Activator activator in activatorList)
        {
            if (activator.gameActive)
            {
                activator.gameObject.SetActive(true);
            }
            else
            {
                activator.gameObject.SetActive(false);
            }
        }
    }
    private void ChangeStateToPause()
    {
        foreach (Activator activator in activatorList)
        {
            if (activator.pauseActive)
            {
                activator.gameObject.SetActive(true);
            }
            else
            {
                activator.gameObject.SetActive(false);
            }
        }
    }

    private void ChangeStateToDead()
    {
        foreach (Activator activator in activatorList)
        {
            if (activator.deadActive)
            {
                activator.gameObject.SetActive(true);
            }
            else
            {
                activator.gameObject.SetActive(false);
            }
        }
    }
}
