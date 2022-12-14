using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimacionesUI_Pause : MonoBehaviour
{

    [SerializeField] private GameObject menuPausal;
    [SerializeField] private GameObject Opciones;
    [SerializeField] private GameObject inventario;
    [SerializeField] private GameObject infomas;

    private bool juegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(juegoPausado)
            {
                renaudar();
            }
            else
            {
                pausa();
            }
        }
    }
    public void pausa()
    {
        juegoPausado=true;
        menuPausal.SetActive(true);
        Time.timeScale = 0f;
    }

    public void renaudar()
    {
        juegoPausado=false;
        menuPausal.SetActive(false);
        Time.timeScale = 1f;

    }

    public void Iventario()
    {
        Opciones.SetActive(false);
        inventario.SetActive(true);
        infomas.SetActive(false);
    }

    public void opciones()
    {
        Opciones.SetActive(true);
        inventario.SetActive(false);
        infomas.SetActive(false);
    }

    public void informacion()
    {
        Opciones.SetActive(false);
        inventario.SetActive(false);
        infomas.SetActive(true);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar()
    {
        Application.Quit();
    } 

}
