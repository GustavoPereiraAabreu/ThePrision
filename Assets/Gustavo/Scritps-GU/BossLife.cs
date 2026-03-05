using UnityEngine;

public class BossLife : MonoBehaviour
{
    public int life = 3;
    public GameObject victoryScreen;

    public void TakeDamage()
    {
        life--;

        if (life <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Boss derrotado!");

        if (victoryScreen != null)
        {
            victoryScreen.SetActive(true);
        }

        Time.timeScale = 0f;
        Destroy(gameObject);
    }
}
