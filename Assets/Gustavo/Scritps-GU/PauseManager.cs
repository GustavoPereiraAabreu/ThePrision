using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;

    private bool _isPaused = false;
    [SerializeField] private GameObject _pauseMenuUI;

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        _isPaused = true;
        Time.timeScale = 0f; // Pausa o tempo do jogo

        if (_pauseMenuUI != null)
            _pauseMenuUI.SetActive(true);

      
    }

    public void Resume()
    {
        _isPaused = false;
        Time.timeScale = 1f; // Volta o tempo normal

        if (_pauseMenuUI != null)
            _pauseMenuUI.SetActive(false);

       
    }

    public bool IsPaused => _isPaused;
}