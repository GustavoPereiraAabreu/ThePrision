using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject victoryScreen;
    public GameObject defeatScreen;

    public void PlayerWin()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayerLose()
    {
        defeatScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}