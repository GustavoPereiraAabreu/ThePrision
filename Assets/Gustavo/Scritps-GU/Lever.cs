using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour, ITouchable
{
    [Header("Configuração de Arte")]
    [SerializeField] private Sprite _artEsquerda; // Arraste a arte da esquerda aqui
    [SerializeField] private Sprite _artDireita;  // Arraste a arte da direita aqui
    private SpriteRenderer _spriteRenderer;

    [Header("Eventos")]
    public UnityEvent OnActive;
    public UnityEvent OnDesactive;
    private bool _isActive = false;

    void Start()
    {
        // Pega o componente que mostra a imagem no Unity
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // Define a imagem inicial (esquerda)
        if (_spriteRenderer != null && _artEsquerda != null)
            _spriteRenderer.sprite = _artEsquerda;
    }

    public void Active()
    {
        _isActive = !_isActive; // Alterna entre ligado/desligado

        if (_isActive)
        {
            // Muda a arte para a direita e abre a porta
            if (_artDireita != null) _spriteRenderer.sprite = _artDireita;
            OnActive.Invoke();
        }
        else
        {
            // Volta a arte para a esquerda e fecha a porta (opcional)
            if (_artEsquerda != null) _spriteRenderer.sprite = _artEsquerda;
            OnDesactive.Invoke();
        }
    }
}