using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Rendering;

public class Bala : MonoBehaviour
{
    public Transform transJogador;
    public Transform transBala;
    public GameObject bala;
    public Rigidbody2D tiro;
    public Vector2 posiçãoJogador;
    public float velocidade = 10f;
    public Vector2 direção;
    public float rotação;
    bool canShot = true;

    void FixedUpdate()
    {
        posiçãoJogador = transJogador.position;
        rotação = transJogador.eulerAngles.z;
    }
    
    public void Atirar()
    {
        if (canShot)
        {
            canShot = false;
            transform.position = posiçãoJogador;
            bala.SetActive(true);
            StartCoroutine(Andar());
            StartCoroutine(Esperar(2));
        }
        
        
    }
    IEnumerator Esperar(int x)
    {
        yield return new WaitForSeconds(x);
        bala.SetActive(false);
        canShot = true;
    }
    private IEnumerator Andar()
    {
        int a = 0;
        transform.Rotate(0, 0, rotação);
        while (a < 0)
            transform.position += transform.forward * velocidade;
            yield return new WaitForSeconds(1f);
    }
}
