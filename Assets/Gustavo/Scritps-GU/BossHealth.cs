using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int life = 5;

    public GameObject victoryScreen;

    public void TakeDamage(int damage)
    {
        life -= damage;

        Debug.Log("Boss Life: " + life);

        if (life <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Boss derrotado");

        victoryScreen.SetActive(true);

        Destroy(gameObject);

        Time.timeScale = 0f;
    }
}