using UnityEngine;
using UnityEngine.InputSystem;

public class Bala : MonoBehaviour
{
    public Transform transJogador;
    public Transform transBala;
    public Rigidbody2D tiro;
    public Vector2 posiçãoJogador;

    void FixedUpdate()
    {
        posiçãoJogador = transJogador.position;
        Debug.Log(posiçãoJogador);
    }
    
    void Esconder()
    {
        tiro.SetActive(false);
    }
    void Mostrar()
    {

        transform.Translate(posiçãoJogador);
        tiro.SetActive(true);
        
    }
}
