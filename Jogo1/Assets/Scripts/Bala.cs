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
    
    //objeto da bala
    public GameObject balax;
    
    public Rigidbody2D tiro;
    Rigidbody2D tiro_ins;

    GameObject novaBala;

    Vector2 input;
    Vector3 posiçaoJogador;

    public Collider2D player_col;
    Collider2D bala_col;

    public float velocidade = 1f;
    bool canShot = true;
    float angulo;
    public float cooldown = 2f;

    public BalaInstanciada ScriptInstanciada;

    Bala script;



    public void Start(){

        Bala script = GetComponent<Bala>();
    }

    public void Direção(InputAction.CallbackContext contexto)
    {
        input = contexto.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        posiçaoJogador = transJogador.position;
        //Debug.Log(input);
        /*
        if (canShot == false)
        {
            script.StartCoroutine(Esperar(cooldown));
        }
        */
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

                //Instanciação da bala
                novaBala = Instantiate(balax, transform.position, Quaternion.identity);
                novaBala.transform.position = posiçaoJogador;

                //atribuimos o script atual ao objeto instanciado
                Bala script = novaBala.GetComponent<Bala>();

                //habilitamos uma outra script no objeto instanciado
                BalaInstanciada ScriptInstanciada = novaBala.GetComponent<BalaInstanciada>();
                ScriptInstanciada.enabled = true;

                bala_col = novaBala.GetComponent<Collider2D>();
                Physics2D.IgnoreCollision(player_col, bala_col);

                tiro_ins = novaBala.GetComponent<Rigidbody2D>();

                //coroutine
                script.StartCoroutine(Andar(novaBala));
                script.StartCoroutine(Esperar(cooldown, novaBala));
            }
        }
    }

    IEnumerator Esperar(float x, GameObject bala )
    {
        yield return new WaitForSeconds(x);
        canShot = true;
        Destroy(bala);
    }
    private IEnumerator Andar(GameObject bala)
    {
        tiro_ins.linearVelocity = input * velocidade;
        yield return null;
    }
}