using UnityEngine;

public class ZonaPuxar : MonoBehaviour
{
    public float forcaPuxao = 5f; 
    private Transform playerTransform;
    private bool playerNaArea = false;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            playerNaArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNaArea = false;
        }
    }

    void Update()
    {
        
        if (playerNaArea && playerTransform != null)
        {
            playerTransform.position = Vector2.MoveTowards(
                playerTransform.position,
                transform.position,
                forcaPuxao * Time.deltaTime);
        }
    }
}