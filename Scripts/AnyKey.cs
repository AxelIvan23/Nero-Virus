using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKey : MonoBehaviour
{
	[SerializeField]
    private ManagerData data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) {
        	data.data.HP = data.data.MaxHP;
        	SceneManager.LoadScene("Menu");
        }
    }
}
