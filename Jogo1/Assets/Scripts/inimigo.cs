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
    public float strengh1;
    public Slider sliderboss;

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


        if (tempoAtual > tempoTotal)
        {
            StartCoroutine(Ataque_base());
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
            atk1 = false;
            StopCoroutine(Ataque_base());
            rb.linearVelocity = Vector2.zero;
        }
    }

    IEnumerator Ataque_base()
    {
        atk1 = true;
        while (atk1 == true)
        {
            rb.AddForce(transform.right * strengh1);
            yield return new WaitForFixedUpdate();
        }
        tempoAtual = 0f;
    }
}
