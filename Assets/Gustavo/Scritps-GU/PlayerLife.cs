using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life = 3;
    public TextMeshProUGUI lifeText;
    public GameObject defeatScreen;

    [Header("Efeito de Dano")]
    public Color damageColor = Color.red;
    public float flashDuration = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Coroutine flashCoroutine;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }

        UpdateLifeUI();
    }

    public void TakeDamage()
    {
        life--;
        UpdateLifeUI();

        if (spriteRenderer != null)
        {
            if (flashCoroutine != null) StopCoroutine(flashCoroutine);
            flashCoroutine = StartCoroutine(FlashDamage());
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
        flashCoroutine = null;
    }

    void UpdateLifeUI()
    {
        if (lifeText != null)
        {
            lifeText.text = "Life: " + life;
        }
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