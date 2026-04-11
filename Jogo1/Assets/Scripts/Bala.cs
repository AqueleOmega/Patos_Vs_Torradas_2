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
    public Transform transJogador;
    public Transform transBala;
    public GameObject bala;
    public Rigidbody2D tiro;
    Vector2 posiçãoJogador;
    public float velocidade = 1f;
    bool canShot = true;
    public float angulo;
    public float cooldown = 2f;
    Vector2 input;
    Vector2 input_usado;


    public void Direção(InputAction.CallbackContext contexto)
    {
        input = contexto.ReadValue<Vector2>();
        Debug.Log(input);
    }

    void Update()
    {
        Debug.Log(input);
        posiçãoJogador = transJogador.position;
        if (canShot == true)
        {
            angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, 0, angulo);
        }
    }

    public void Atirar()
    {
        if (canShot == true)
        {
            Debug.Log("Pode atirar");
            Debug.Log(input);
            if (input != new Vector2(0,0))
            {
                Debug.Log("tirando");
                canShot = false;
                GameObject novaBala = Instantiate(bala, transform.position, Quaternion.identity);
                transform.position = posiçãoJogador;
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