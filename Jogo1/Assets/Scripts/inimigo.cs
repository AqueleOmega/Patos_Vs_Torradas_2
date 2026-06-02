using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Video;
using static UnityEngine.GraphicsBuffer;

public class inimigo : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D C2D;
    public float vida;
    float tempoAtual = 0f;
    float tempoTotal = 3f;
    inimigo script;
    public Transform jogador;
    bool atk1;
    bool atk;
    bool atk2;
    bool parte2 = false;
    bool atk3 = false;
    bool pulo = false;
    public float strengh1;
    public float strenght2;
    public float strenght3;
    public float aproximation;
    public Slider sliderboss;
    public Sprite sprite;
    Sprite quadrado;
    public SpriteRenderer sr; 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //Sprite quadrado = sr.sprite;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        tempoAtual += Time.deltaTime;

        if (atk1 == false && parte2 == false)
        {
            
            Vector2 direcao = jogador.position - transform.position;
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

            transform.eulerAngles = new Vector3(0, 0, angulo);
            
        }

        // Isso tá rodando todo frame
        if (tempoAtual > tempoTotal && atk == false)
        {
            int escolha;
            escolha = Random.Range(1,4);
            Debug.Log(escolha);

            if (escolha == 1)
            {
                StartCoroutine(Ataque_base());
            }
            if (escolha == 2)
            {
                StartCoroutine(Pulo());
            }
            if (escolha == 3)
            {
                StartCoroutine(Pursuit());
            }
        }

        sliderboss.value = vida;
        if (vida <= 0)
        {
            gameObject.transform.position = new Vector2(0, 100);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            vida -= 1;
        }
        if (collision.gameObject.CompareTag("Parede"))
        {
            if (atk1 == true){
                atk = false;
                atk1 = false;
                StopCoroutine(Ataque_base());
                rb.linearVelocity = Vector2.zero;
            }
            if(atk2 == true){
                rb.linearVelocity = Vector2.zero;
            }
            if (atk3 == true){
                rb.linearVelocity = Vector2.zero;
            }
        }
    }

    IEnumerator Ataque_base()
    {
        atk = true;
        atk1 = true;
        while (atk1 == true)
        {
            rb.AddForce(transform.right * strengh1);
            yield return new WaitForFixedUpdate();
        }
        tempoAtual = 0f;
        atk = false;
        atk1 = false;
        yield return null;
    }

    IEnumerator Pulo()
    {
        atk = true;
        atk2 = true;
        bool parte1 = true;
        bool parte2 = false;
        bool parte3 = false;
        float tempo_2 = 0;
        float tempo_3 = 0;

        Vector3 scale = transform.localScale;
        while (parte1 = true && transform.localScale != new Vector3(0,0,0))
        {
            transform.localScale = transform.localScale - new Vector3(strenght2,strenght2,strenght2);
            yield return new WaitForFixedUpdate();
        }
        parte1 = false;
        parte2 = true;

        
        yield return new WaitForSeconds(1f);
        transform.localScale = scale;
        C2D.enabled = false;

        while (tempo_3 <= 3f)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, jogador.position, aproximation * Time.deltaTime);
            tempo_3 += 1f * Time.deltaTime;
            yield return new WaitForFixedUpdate();
            
            
        }
        tempo_3 = 0;

        yield return new WaitForSeconds(1f);

        //sr.sprite = quadrado;
        C2D.enabled = true;
        parte2 = false;
        parte3 = true;

        tempoAtual = 0f;
        atk = false;
        atk2 = false;
        yield return null;
        
    }

    IEnumerator Pursuit()
    {
        atk = true;
        atk3 = true;
        while (strenght3 <= 10f)
        {
            rb.AddForce(transform.right * strenght3);
            strenght3 += 0.01f;
            yield return new WaitForFixedUpdate();
            
        }
        atk3 = false;
        atk = false;
        tempoAtual = 0f;
        rb.linearVelocity = new Vector2(0, 0);
        yield return null;
    }

}
