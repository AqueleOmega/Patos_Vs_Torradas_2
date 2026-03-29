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
    public movimentação angulon;
    public float cooldown = 2f;

    void Update()
    {
        posiçãoJogador = transJogador.position;
        if (canShot)
        {
            transform.localRotation = Quaternion.Euler(0, 0, angulon.angulo);
        }

    }
    
    public void Atirar()
    {

        if (canShot)
        {
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

    IEnumerator Esperar(float x,  GameObject bala)
    {
        yield return new WaitForSeconds(x);
        canShot = true;
        bala.SetActive(false);  
    }
    private IEnumerator Andar()
    {
        tiro.linearVelocity = angulon.input * velocidade;
        yield return null;
    }
}
