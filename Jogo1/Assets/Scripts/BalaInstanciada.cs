using UnityEngine;

public class BalaInstanciada : MonoBehaviour
{
    bool parede;
    bool inimigo;

    void Start()
    {
        Debug.Log("Fui habilitada");
        //Physics2D.IgnoreCollision(player_col, bala_col);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (parede == true)
        {
            //gameObject.transform.position = new Vector3(0, 1000, 0);
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colidiu");

        if (collision.gameObject.CompareTag("inimigo"))
        {
            transform.position = new Vector3(0, 1000, 0);
            Debug.Log("Colidiu com o inimigo");
        }
        if (collision.gameObject.CompareTag("Parede"))
        {
            transform.position = new Vector3(0, 1000, 0);
            Debug.Log("Colodiu com a parede");
        }
    }
}
