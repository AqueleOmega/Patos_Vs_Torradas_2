using UnityEngine;
using UnityEngine.InputSystem;

public class rotationbody : MonoBehaviour
{
   Vector2 input; 
   public Transform cabeça;
   public Transform corpo;
   float angulo;
   public Animator head;

   public void Direção(InputAction.CallbackContext contexto)
    {
        input = contexto.ReadValue<Vector2>();
    }
    
    void FixedUpdate()
    {
        if (input.x > 0){
            head.SetBool("Direita", true);
            head.SetBool("Esquerda", false);
        }
        if (input.x < 0){
            head.SetBool("Direita", false);
            head.SetBool("Esquerda", true);
        }

        Debug.Log(input);
    }

}
