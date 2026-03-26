using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Bala : MonoBehaviour
{
    public Transform transJogador;
    public Transform transBala;
    public GameObject bala;
    public Rigidbody2D tiro;
    public Vector2 posiçãoJogador;

    void FixedUpdate()
    {
        posiçãoJogador = transJogador.position;
        Debug.Log(posiçãoJogador);
    }
    
    void Esconder()
    {
        bala.SetActive(false);
    }

    public void Atirar()
    {
        transform.position = posiçãoJogador;
        bala.SetActive(true);
        StartCoroutine(Esperar(2));
        
    }

    IEnumerator Esperar(int x)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(x);
        bala.SetActive(false);
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
