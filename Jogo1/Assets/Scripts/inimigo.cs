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
    public float vida;
    float tempoAtual = 0f;
    float tempoTotal = 3f;
    inimigo script;
    public Transform jogador;
    bool atk1;
    bool atk;
    bool atk2;
    public float strengh1;
    public float strenght2;
    public Slider sliderboss;
    public Sprite sprite;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tempoAtual += Time.deltaTime;

        if (atk1 == false)
        {
            
            Vector2 direcao = jogador.position - transform.position;
            float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

            transform.eulerAngles = new Vector3(0, 0, angulo);
            
        }

        // Isso tá rodando todo frame
        if (tempoAtual > tempoTotal)
        {
            StartCoroutine(Pulo());
            //StartCoroutine(Ataque_base());
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
    }

    IEnumerator Pulo()
    {
        atk = true;
        atk2 = true;
        bool parte1 = true;
        Vector3 scale = transform.localScale;
        while (parte1 = true && transform.localScale != new Vector3(0,0,0))
        {
            transform.localScale = transform.localScale - new Vector3(strenght2,strenght2,strenght2);
            yield return new WaitForFixedUpdate();
        }
        parte1 = false;
        Debug.Log("era pra ter acabado");
        yield return new WaitForSeconds(0.4f);
        transform.localScale = scale;
    }

}
