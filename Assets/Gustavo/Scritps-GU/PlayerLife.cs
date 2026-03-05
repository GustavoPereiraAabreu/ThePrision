using UnityEngine;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    public int life = 3;
    public TextMeshProUGUI lifeText;

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
        Debug.Log("Player morreu");
        Time.timeScale = 0f;
    }
}