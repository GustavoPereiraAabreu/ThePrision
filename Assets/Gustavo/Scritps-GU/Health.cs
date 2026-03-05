using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Configurações de Vida")]
    public int maxHealth = 10;
    private int currentHealth;

    [Header("UI - Arraste a tela correspondente aqui")]
    public GameObject screenToShowOnDeath;

    void Start()
    {
        currentHealth = maxHealth;
        // Garante que a tela comece desativada
        if (screenToShowOnDeath != null)
            screenToShowOnDeath.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Ativa a tela (Vitória ou Derrota) que você arrastou no Inspector
        if (screenToShowOnDeath != null)
        {
            screenToShowOnDeath.SetActive(true);
        }

        // Faz o objeto sumir
        gameObject.SetActive(false);
    }
}