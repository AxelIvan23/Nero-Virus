using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;

    private Vector2 offset;

    private Material material;

    [SerializeField]
    private GameObject[] Characters;
    [SerializeField]
    private ManagerData data;
    int num=0;
    private Vector3 actualPos;
    private Vector3 diffPos; 

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        num = data.data.Player;
    }

    // Update is called once per frame
    void Update()
    {
    	actualPos = actualPos - Characters[num].transform.position;
    	Debug.Log(Vector3.Normalize(actualPos));
        offset = velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
