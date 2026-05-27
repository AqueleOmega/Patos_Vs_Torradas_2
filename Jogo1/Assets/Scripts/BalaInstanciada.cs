using System.Collections;
using UnityEngine;

public class BalaInstanciada : MonoBehaviour
{
    

    void Start()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = new Vector3(0, 1000, 0);
        }
        if (collision.gameObject.CompareTag("Parede"))
        {
            transform.position = new Vector3(0, 1000, 0);
        }
    }
}
