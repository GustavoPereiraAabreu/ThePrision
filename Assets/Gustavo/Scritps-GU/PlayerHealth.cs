using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int life = 3;
    public TextMeshProUGUI lifeText;
    public GameObject defeatScreen;

    void Start()
    {
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        UpdateUI();

        if (life <= 0)
        {
            Die();
        }
    }

    void UpdateUI()
    {
        lifeText.text = "Life: " + life;
    }

    void Die()
    {
        Debug.Log("Player morreu");

        defeatScreen.SetActive(true);

        Time.timeScale = 0f;
    }
}