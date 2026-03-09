using UnityEngine;
using System.Collections; 

public class BossLife : MonoBehaviour
{
    public int life = 3;
    public GameObject victoryScreen;

    [Header("Configurações de Visual")]
    public Color damageColor = Color.red;
    public float flashDuration = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    public void TakeDamage()
    {
        life--;

       
        if (spriteRenderer != null)
        {
            StartCoroutine(FlashDamage());
        }

        if (life <= 0)
        {
            Die();
        }
    }

   
    IEnumerator FlashDamage()
    {
        spriteRenderer.color = damageColor; 
        yield return new WaitForSeconds(flashDuration); 
        spriteRenderer.color = originalColor; 
    }

    void Die()
    {
        if (victoryScreen != null)
        {
            victoryScreen.SetActive(true);
        }

        Time.timeScale = 0f;
        Destroy(gameObject);
    }
}