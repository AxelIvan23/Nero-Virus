using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float damage;

    private void Update()
    {
        transform.Translate(Vector2.right*velocidad*Time.deltaTime*transform.localScale.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Slime"))
        {
            collision.GetComponent<Enemigo>().TomarDano(damage);
            Destroy(gameObject);
        }
    }
}
