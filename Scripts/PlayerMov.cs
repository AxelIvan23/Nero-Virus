using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
	private int dir = 0;
	private float vel;
	private int conversation=0;
	private Animator anim;
	private SpriteRenderer renderer;
	[SerializeField]
	private GameObject notification;
	[SerializeField]
	private GameObject camera;
	[SerializeField]
	private DialogSystem dialogSystem;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        vel = Screen.width / 700000.0f;
    }

    // Update is called once per frame
    void Update()
    {
    	dir=0;
        if (Input.GetKey(KeyCode.UpArrow)) {
        	dir=dir+1;
        	gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + vel);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
        	dir=dir+2;
        	gameObject.transform.position = new Vector2(gameObject.transform.position.x + vel, gameObject.transform.position.y);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
        	dir=dir+4;
        	gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - vel);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
        	dir=dir+7;
        	gameObject.transform.position = new Vector2(gameObject.transform.position.x - vel, gameObject.transform.position.y);
        }
        switch(dir) {
        	case 1: anim.SetInteger("state",1); renderer.flipX = false; break;
        	case 2: anim.SetInteger("state",2); renderer.flipX = true; break;
        	case 3: anim.SetInteger("state",3); renderer.flipX = true; break;
        	case 4: anim.SetInteger("state",4); renderer.flipX = false; break;
        	case 6: anim.SetInteger("state",6); renderer.flipX = true; break;
        	case 7: anim.SetInteger("state",7); renderer.flipX = false; break;
        	case 8: anim.SetInteger("state",8); renderer.flipX = false; break;
        	case 11: anim.SetInteger("state",11); renderer.flipX = false; break;
        	case 0: anim.SetInteger("state",0); break;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
        	if (conversation>0) {
	        	dialogSystem.enabled = true;
	        	dialogSystem.StartConversation(conversation-1);
        	}
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shop") {
        	notification.SetActive(true);
        	conversation=1;
        }
        if (other.tag == "Chest") {
        	notification.SetActive(true);
        	conversation=2;
        }
        if (other.tag == "Finish") {
        	camera.transform.position = new Vector3(-2.15f,-16.93f,-10);
        	gameObject.transform.position = new Vector3(-2.22f,-16.71f,0);
        	camera.transform.parent = gameObject.transform;
        }
        if (other.tag == "Player") {
        	camera.transform.parent = null;
        	camera.transform.position = new Vector3(0,0,-10);
        	gameObject.transform.position = new Vector3(-4.55f,-3.63f,0);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
    	conversation=0;
    	notification.SetActive(false);
    }

}
