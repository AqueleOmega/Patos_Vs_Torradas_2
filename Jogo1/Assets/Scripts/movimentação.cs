using UnityEngine;
using UnityEngine.InputSystem;

public class movimentação : MonoBehaviour
{
    Vector2 input;
    public float velocidade = 5f;
    public Rigidbody2D rb;
    bool movendo = false;
    public float friction = 0.98f;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Movimentar(InputAction.CallbackContext contexto)
    {
        movendo = true;
        input = contexto.ReadValue<Vector2>();
        if (contexto.canceled){
            movendo = false;
        }
    }

    void FixedUpdate()
    {
        if (movendo == true){
            rb.linearVelocity = input * velocidade;
        }
        else{
            rb.linearVelocity *= friction;
        }
    }


}
