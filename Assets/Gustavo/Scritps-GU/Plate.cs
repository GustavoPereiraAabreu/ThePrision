using UnityEngine;

public class Plate : MonoBehaviour
{
    [Header("Pressure Plate Settings")]
    [SerializeField] private float _activationDelay = 0.1f;
    [SerializeField] private int _objectsNeeded = 1;

    private int _objectsOnPlate = 1;
    private bool _playerOnPlate = false;
    private bool _isActivated = false;
    private float _activationTimer = 1f;

    private void Update()
    {
        // Verificar se deve desativar
        if (_isActivated && _objectsOnPlate < _objectsNeeded && !_playerOnPlate)
        {
            _isActivated = false;
            OnDeactivate();
        }

        // Timer para ativação
        if (_activationTimer > 0)
        {
            _activationTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar se é o player
        if (collision.CompareTag("Player"))
        {
            _playerOnPlate = true;
            TryActivate();
            return;
        }

        // Senão é um objeto
        _objectsOnPlate++;
        TryActivate();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verificar se é o player
        if (collision.CompareTag("Player"))
        {
            _playerOnPlate = false;

            if (_objectsOnPlate < _objectsNeeded && _isActivated)
            {
                _isActivated = false;
                OnDeactivate();
            }
            return;
        }

        // Senão é um objeto
        _objectsOnPlate--;

        if (_objectsOnPlate < _objectsNeeded && !_playerOnPlate && _isActivated)
        {
            _isActivated = false;
            OnDeactivate();
        }
    }

    private void TryActivate()
    {
        if (!_isActivated && _activationTimer <= 0)
        {
            if (_playerOnPlate || _objectsOnPlate >= _objectsNeeded)
            {
                _isActivated = true;
                _activationTimer = _activationDelay;
                OnActivate();
            }
        }
    }

    private void OnActivate()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void OnDeactivate()
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public bool IsActivated => _isActivated;
}