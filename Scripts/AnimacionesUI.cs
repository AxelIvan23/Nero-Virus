using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesUI : MonoBehaviour
{
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject btnjuego;
    [SerializeField] private GameObject btnopciones;
    [SerializeField] private GameObject btnsalir;

    [SerializeField] private GameObject fondo;
    [SerializeField] private GameObject marcoopc;
    [SerializeField] private GameObject btn_cerrar;
    [SerializeField] private GameObject txtgeneral;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void muestrabotones()
    {
        LeanTween.alpha(btnjuego.GetComponent<RectTransform>(), 1f, 1f).setEase(LeanTweenType.easeInOutQuart);

        LeanTween.alpha(btnopciones.GetComponent<RectTransform>(), 1f, 1f).setEase(LeanTweenType.easeInOutQuart).setDelay(1f);

        LeanTween.alpha(btnsalir.GetComponent<RectTransform>(), 1f, 1f).setEase(LeanTweenType.easeInOutQuart).setDelay(2f);

        LeanTween.alpha(logo.GetComponent<RectTransform>(), 0f, 1f).setDelay(3f);
        LeanTween.alpha(logo.GetComponent<RectTransform>(), 1f, 1f).setDelay(4f);
    }

    public void abriropciones()
    {
        LeanTween.alpha(fondo.GetComponent<RectTransform>(), 0.8f, 1f).setEase(LeanTweenType.easeInOutQuart);
        LeanTween.moveX(marcoopc.GetComponent<RectTransform>(), 0, 1f).setEase(LeanTweenType.easeInOutQuart);
        LeanTween.moveY(btn_cerrar.GetComponent<RectTransform>(),450,1f).setEase(LeanTweenType.easeInOutQuart);
        LeanTween.moveY(txtgeneral.GetComponent<RectTransform>(), 340, 1f).setEase(LeanTweenType.easeInOutQuart);

    }

    public void cerraropciones()
    {
        LeanTween.alpha(fondo.GetComponent<RectTransform>(), 0f, 1f).setEase(LeanTweenType.easeInOutQuart);
        LeanTween.moveX(marcoopc.GetComponent<RectTransform>(), -1851, 1f).setEase(LeanTweenType.easeInOutQuart);
        LeanTween.moveY(btn_cerrar.GetComponent<RectTransform>(), 713, 1f).setEase(LeanTweenType.easeInOutQuart);
        LeanTween.moveY(txtgeneral.GetComponent<RectTransform>(), 710, 1f).setEase(LeanTweenType.easeInOutQuart);
    }

    public void animateStart() {
        LeanTween.alpha(btnjuego.GetComponent<RectTransform>(), 0f, 0f);
        LeanTween.alpha(btnopciones.GetComponent<RectTransform>(), 0f, 0f);
        LeanTween.alpha(btnsalir.GetComponent<RectTransform>(), 0f, 0f);
        LeanTween.alpha(fondo.GetComponent<RectTransform>(), 0f, 0f);
        LeanTween.moveX(logo.GetComponent<RectTransform>(), 480, 10f).setEase(LeanTweenType.easeInOutQuart)
            .setOnComplete(muestrabotones);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
