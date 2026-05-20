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
    
    public Collider2D player_col;
    public Collider2D bala_col;
    //objeto da bala
    public GameObject bala;
    
    public Rigidbody2D tiro;

    public script Script2;

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
        Script2 = GetComponent<Script2>();
    }

    public void Atirar()
    {
        if (canShot == true)
        {
            if (input != new Vector2(0,0))
            {
                canShot = false;
                //parte que mexe na rotação
                angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(0, 0, angulo);
                Physics2D.IgnoreCollision(player_col, bala_col);
                GameObject novaBala = Instantiate(bala, transform.position, Quaternion.identity);
                transform.position = new Vector3 (posiçaoJogador.x, posiçaoJogador.y, 0);
                Script2 script = novaBala.GetComponent<Script2>();
                var sr = novaBala.GetComponent<SpriteRenderer>();
                sr.enabled = true;

                script.StartCoroutine(Andar());
                script.StartCoroutine(Esperar(cooldown, novaBala));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            Destroy(bala);
        }
    }
}