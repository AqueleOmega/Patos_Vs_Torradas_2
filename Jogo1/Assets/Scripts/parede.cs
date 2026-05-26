using UnityEngine;

public class parede : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            //collision.transform.position = new Vector3(0, 1000, 0);
        }
    }
}
