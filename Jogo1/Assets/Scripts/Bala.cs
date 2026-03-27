using NUnit.Framework.Constraints;
using System.Collections;
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

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void Update()
    {
        posiçãoJogador = transJogador.position;
        Debug.Log(canShot);
        if (canShot)
        {
            transform.localRotation = Quaternion.Euler(0, 0, angulon.angulo);
            transBala.position = posiçãoJogador;
            Debug.Log(transBala.position);
            Debug.Log(transJogador.position);
        }
        
    }
    
    public void Atirar()
    {

        if (canShot)
        {
            canShot = false;
            //GameObject novaBala = Instantiate(bala, transform.position, Quaternion.identity);
            //novaBala.transform.position = posiçãoJogador;
            //Bala script = novaBala.GetComponent<Bala>();
            //novaBala.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(Andar());
            StartCoroutine(Esperar(2f));
        }
    }

    IEnumerator Esperar(float x)
    {
        Debug.Log(x);
        yield return new WaitForSeconds(x);
        canShot = true;
        GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Foi");
    }
    private IEnumerator Andar()
    {
        Debug.Log("Andou");
        tiro.linearVelocity = angulon.input * velocidade;
        yield return null;
    }
}
