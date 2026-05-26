using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Video;

public class inimigo : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vida;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // andar
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            //collision.transform.position = new Vector3(0, 1000, 0);
            vida -= 1;
            Debug.Log(vida);
        }
    }
}
