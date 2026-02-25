using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class TopDownMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _movement;
    [Header("Variables")]
    [SerializeField] private float _speed;

    private void Awake()
    {
        

    }

    private void OnEnable()
    {
        

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
      _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //fisica
        _rb.linearVelocity = _movement * _speed; //Atribuindo o controle à fisica
    }

    // Update is called once per frame
    public void Update()
    {
        //Todo o resto
        //principalmente verificaçao de botão
        _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void LateUpdate()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);

        //Mover camera
        //Objetos que seguem o player
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent(out ITouchable target))
        {
            target.Active();
        }
    }

    private void OnBecameInvisible()
    {
        //quando o objeto com sprite sair das cameras

    }

    private void OnBecameVisible()
    {
        //quando objeto com sprite entrar nas cameras

    }

    private void OnApplicationQuit()
    {
        //Quando o jogo fecha
    }

   private void OnApplicationFocus(bool focus)
   {
        if (focus)
        {
            //algo acontecer se o jogador volta para o jogo
        }
        else
        {
            // algo acontece se o jogador não esta no jogo
        }

   }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            //0 time scale esta 0

        }
        else
        {
            //0 timescale esta 1
        }
    }

    private void OnDestroy()
    {
        // Nunca usar Instantiate aqui
    }

    private void OnDisable()
    {
      
    }
    private void OnDrawGizmos()
    {
        //"Update" dos elemnetos de editor
    }

    private void OnMouseDown()
    {
        //quando clica no objeto com collider
    }

    private void OnMouseEnter()
    {
        //quando o mouse entra no colisor
    }
    private void OnMouseDrag()
    {
        //quando esta pressionado no colisor
    }

    private void OnMouseExit()
    {
        //quando o mouse sai do colisor
    }
    private void OnMouseOver()
    {
        //quando o cursor do mouse esta sobre a colisao
    }
    private void OnMouseUp()
    {
        //quando solta o clique no colisor
    }
    private void OnTransformChildrenChanged()
    {
        //Quando o filho muda
    }

    private void OnBeforeTransformParentChanged()
    {
        //Qyando o pai muda
    }
    private void OnValidate()
    {
        //Quando algum valor é altereado no inspector no modo editor
    }
}

