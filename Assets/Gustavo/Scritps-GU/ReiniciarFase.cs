using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarFase : MonoBehaviour
{
   
    public void StartGame()
    {
        SceneManager.LoadScene("BossFight");
        Time.timeScale = 1f;
    }
}