using UnityEngine;
using UnityEngine.InputSystem;

public class rotationbody : MonoBehaviour
{
   Vector2 input; 
   public Transform cabeça;
   public Transform corpo;
   float angulo;

   public void Direção(InputAction.CallbackContext contexto)
    {
        input = contexto.ReadValue<Vector2>();
    }
    
    void FixedUpdate()
    {
        Debug.Log(input);
        angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
        if (angulo != 0){
            cabeça.localRotation = Quaternion.Euler(0, 0, angulo);
        }
        cabeça.localPosition = new Vector3(corpo.position.x, corpo.position.y, -0.01f);
    }

}
