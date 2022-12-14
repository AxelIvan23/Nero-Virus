using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
	private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Hit" || other.tag == "Damage") {
            transform.GetChild(0).gameObject.SetActive(true);
            anim.SetInteger("State",1);
        }
    }

    public void destroy() {
    	Destroy(gameObject);
    }
}
