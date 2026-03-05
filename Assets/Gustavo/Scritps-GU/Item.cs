using UnityEngine;

public class Item : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Coletar();
        }
    }

    void Coletar()
    {
        Debug.Log("Item coletado!");
        Destroy(gameObject);
    }
}