using UnityEngine;
using UnityEngine.InputSystem;

public class movimentação : MonoBehaviour
{
    Vector2 input;
    public float velocidade = 5f;
    public Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Movimentar(InputAction.CallbackContext contexto)
    {
        input = contexto.ReadValue<Vector2>();
    }

    void Update()
    {
        rb.linearVelocity = input * velocidade;
    }


}
