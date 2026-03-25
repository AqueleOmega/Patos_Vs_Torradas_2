using UnityEngine;
using UnityEngine.InputSystem;

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
        StartCoroutine(ExampleCoroutine());
        bala.SetActive(false);
        
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
