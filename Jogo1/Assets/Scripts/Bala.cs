using NUnit.Framework.Constraints;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Windows;


public class Bala : MonoBehaviour
{
    //transform do jogador e da bala
    public Transform transJogador;
    public Transform transBala;
    
    //objeto da bala e da cabeça
    public GameObject bala;
    
    public Rigidbody2D tiro;

    Vector2 input;
    Vector2 posiçaoJogador;

    public float velocidade = 1f;
    bool canShot = true;
    float angulo;
    public float cooldown = 2f;


    public void Start(){
        
    }

    public void Direção(InputAction.CallbackContext contexto)
    {
        input = contexto.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        posiçaoJogador = transJogador.position;
    }

    public void Atirar()
    {
        if (canShot == true)
        {
            if (input != new Vector2(0,0))
            {
                Debug.Log("tirando");
                canShot = false;
                //parte que mexe na rotação
                angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(0, 0, angulo);

                GameObject novaBala = Instantiate(bala, transform.position, Quaternion.identity);
                transform.position = posiçaoJogador;
                Bala script = novaBala.GetComponent<Bala>();
                var sr = novaBala.GetComponent<SpriteRenderer>();
                sr.enabled = true;
                script.StartCoroutine(Andar());
                script.StartCoroutine(Esperar(cooldown, novaBala));
            }
        }
    }

    IEnumerator Esperar(float x,  GameObject bala)
    {
        yield return new WaitForSeconds(x);
        canShot = true;
        Destroy(bala);
    }
    private IEnumerator Andar()
    {
        tiro.linearVelocity = input * velocidade;
        yield return null;
    }
}