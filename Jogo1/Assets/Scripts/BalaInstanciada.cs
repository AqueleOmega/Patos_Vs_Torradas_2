using System.Collections;
using UnityEngine;

public class BalaInstanciada : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    Bala script1;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.linearVelocity == new Vector2(0,0)) {
            transform.position = new Vector3(0, 1000, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = new Vector3(0, 1000, 0);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Parede"))
        {
            transform.position = new Vector3(0, 1000, 0);
            Destroy(gameObject);
        }
    }

}
