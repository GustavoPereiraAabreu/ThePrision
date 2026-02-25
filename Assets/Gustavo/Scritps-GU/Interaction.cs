using UnityEngine;

public class Interaction : MonoBehaviour
{
    private IInteractable _target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_target == null)
            return;
        if (Input.GetButtonDown("Fire1"))
        {  
            _target.Activte();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out _target))
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

       _target = null;
        
    }

}
