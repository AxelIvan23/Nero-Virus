using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;

    private Material material;

    [SerializeField] private GameObject jugadorrb;
    private Rigidbody2D jugador;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        jugador = jugadorrb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        offset = velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
