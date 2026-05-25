using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Video;
using UnityEngine.UI;

public class inimigo : MonoBehaviour
{
    public Rigidbody2D rb;

    public float vida;

    Vector3 position_death;

    public Slider slidervida;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        slidervida.value = vida;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            collision.transform.position = new Vector3(0, 1000, 0);
            vida -= 1;
            Debug.Log(vida);
            position_death = collision.transform.position;
            Debug.Log(position_death);
            collision.transform.position = new Vector3 (100,0,0);
        }
    }
}
