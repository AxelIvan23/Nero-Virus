using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bola;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        Instantiate(bola, controladorDisparo.position, controladorDisparo.rotation);
    }
}
