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
        Debug.Log("Metodo Chamado");
        //Debug.Log(canShot);
        if (canShot == true)
        {
            Debug.Log(input);
            Debug.Log("Possivel atirar");
            if (input != new Vector2(0,0))
            {
                Debug.Log("Inicio do Processo");
                canShot = false;
                //parte que mexe na rotação
                angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(0, 0, angulo);
                //Debug.Log("Fim da rotação");

                //Instanciação da bala
                novaBala = Instantiate(balax, transform.position, Quaternion.identity);
                novaBala.transform.position = posiçaoJogador;
                //Debug.Log("Instanciação concluida");

                //atribuimos o script atual ao objeto instanciado
                Bala script = novaBala.GetComponent<Bala>();
                //Debug.Log("script atribuida");

                //habilitamos uma outra script no objeto instanciado
                BalaInstanciada ScriptInstanciada = novaBala.GetComponent<BalaInstanciada>();
                ScriptInstanciada.enabled = true;
                //Debug.Log("Script 2 ligada");
                bala_col = novaBala.GetComponent<Collider2D>();
                Physics2D.IgnoreCollision(player_col, bala_col);

                var sr = novaBala.GetComponent<SpriteRenderer>(); //habilita o sprite renderer
                sr.enabled = true;

                tiro_ins = novaBala.GetComponent<Rigidbody2D>();
                //Debug.Log("Rigidbody atribuido");

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
        //Debug.Log("era pra ser true");
        Destroy(bala);
    }
    private IEnumerator Andar(GameObject bala)
    {
        tiro_ins.linearVelocity = input * velocidade;
        yield return null;
    }
}