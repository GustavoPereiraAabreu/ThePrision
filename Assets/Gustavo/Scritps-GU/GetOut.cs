using UnityEngine;
using UnityEngine.SceneManagement;

public class GetOut : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
