using UnityEngine;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life = 3;
    public TextMeshProUGUI lifeText;

    public GameObject defeatScreen;

    void Start()
    {
        UpdateLifeUI();
    }

    public void TakeDamage()
    {
        life--;
        UpdateLifeUI();

        if (life <= 0)
        {
            Die();
        }
    }

    void UpdateLifeUI()
    {
        lifeText.text = "Life: " + life;
    }

    void Die()
    {
    

        if (defeatScreen != null)
        {
            defeatScreen.SetActive(true);
        }

        Time.timeScale = 0f;

    }

      
}