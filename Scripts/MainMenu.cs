using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField]
	private GameObject[] characters;
	[SerializeField]
	private bool[] disponibles;
	[SerializeField]
	private RectTransform marco;
	[SerializeField]
    private ManagerData data;

	int num=1;
	public int mode=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
        	num=num+1;
        	if (num>4)
        		num=1;
        	selectPersonaje();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
        	num=num-1;
        	if (num<1)
        		num=4;
        	selectPersonaje();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
        	num=num-2;
        	if (num<1)
        		num=num+4;
        	selectPersonaje();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
        	num=num+2;
        	if (num>4)
        		num=num-4;
        	selectPersonaje();
        }
    }

    public void selectPersonaje() {
    	if (mode==1) {
	    	if (num==1)
	        	marco.anchoredPosition = new Vector2(145f,162f);
	        if (num==2)
	        	marco.anchoredPosition = new Vector2(470f,162f);
	        if (num==3)
	        	marco.anchoredPosition = new Vector2(145f,-194f);
	        if (num==4)
	        	marco.anchoredPosition = new Vector2(470f,-194f);

	        data.data.Player=num;

	        for (int i=0;i<characters.Length;i++) {
	        	if (i==num-1)
	        		characters[i].SetActive(true);
	        	else
	        		characters[i].SetActive(false);
	        }
	    }
    }

    public void cargarEscena(string escena)
    {
    	if (mode==1) {
	    	if (disponibles[num-1]==true) {
	        	SceneManager.LoadScene(escena);
	    	}
	    } else
	    	SceneManager.LoadScene(escena);
    }

    public void salir()
    {
        Application.Quit();
    }
}

