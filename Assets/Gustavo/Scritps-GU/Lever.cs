using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _once;
    [SerializeField] private bool _isActive;
    [SerializeField] private UnityEvent OnActive;
    [SerializeField] private UnityEvent OnDesactive;

    public void Activte()
    {
        if (_isActive) 
        {
            OnDesactive.Invoke();
        }
        else
        {
            OnActive.Invoke();
        }
        _isActive = !_isActive;

        if(_once)
          Destroy(this);
    }

 
}
