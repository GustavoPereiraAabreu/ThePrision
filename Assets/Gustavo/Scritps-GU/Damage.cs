using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 10;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o que atingimos tem o script de vida
        Health hp = collision.GetComponent<Health>();

        if (hp != null)
        {
            hp.TakeDamage(1); // Tira 1 de vida
        }
    }
}