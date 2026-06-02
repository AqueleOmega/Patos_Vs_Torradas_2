using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class movimentação : MonoBehaviour
{
    public Vector2 input;
    public float velocidade = 5f;
    public Rigidbody2D rb;

    bool movendox = false;
    bool movendoy = false;
    
    public float friction = 0.98f;
    float angulo;

    public Slider slidervida;
    public float vida = 10f;

    float tempo = 0;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Movimentar(InputAction.CallbackContext contexto)
    {
        input = contexto.ReadValue<Vector2>();
        if (input.x != 0)
        {
            movendox = true;
        }

        else
        {
            movendox = false;
        }

        if (input.y != 0)
        {
            movendoy = true;
        }

        else
        {
            movendoy = false;
        }
    }

    void FixedUpdate()
    {
        if (movendox == true)
        {
            rb.linearVelocity = new Vector2(input.x * velocidade, rb.linearVelocity.y);
        }

        else
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x * friction, rb.linearVelocity.y);
        }

        if (movendoy == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, input.y * velocidade);
        }

        else
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * friction);
        }
        // rotação corpo
        angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angulo);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            vida -= 1;
            slidervida.value = vida;
            if (vida <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            tempo += Time.deltaTime;
            if (tempo >= 1f)
            {
                vida -= 1;
                slidervida.value = vida;
                tempo = 0f;
            }
        }
    }
}
