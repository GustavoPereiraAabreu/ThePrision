using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public TextMeshProUGUI healthText;

    void Start()
    {
        gameObject.tag = "Player";
        UpdateHealth();
    }

    public void TakeDamage()
    {
        health--;
        UpdateHealth();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateHealth()
    {
        healthText.text = "Vida: " + health;
    }
}