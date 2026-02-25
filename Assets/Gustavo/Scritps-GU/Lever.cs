using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private bool _once;
    private bool _isPressed;
    public UnityEvent OnActive;
    public UnityEvent OnDesactive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IStatusPlayer player))
        {

            OnActive.Invoke();
            if (_once)
                Destroy(this);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IStatusPlayer player))
        {

            OnDesactive.Invoke();

        }
    }
}
