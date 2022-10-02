using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
	private int dir = 0;
	public float vel;
    public bool canJump = true;
	//private int conversation=0;
	private Animator anim;
    private Rigidbody2D body;
    [SerializeField]
	private DialogSystem dialogSystem;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = new Vector2(Input.GetAxis("Horizontal")*vel,0); 
            //body.AddForce(transform.right * vel);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x+(velocity.x*Time.deltaTime),gameObject.transform.position.y,0);
        if (Input.GetKeyDown ("space") && canJump==true){
            //transform.Translate(Vector3.up * 2.6f * Time.deltaTime, Space.World);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(velocity.x/1.8f, 2.8f), ForceMode2D.Impulse);
            canJump=false;
        }
        //body.MovePosition(body.position + velocity * Time.fixedDeltaTime);
        	//gameObject.transform.position = new Vector2(gameObject.transform.position.x + vel, gameObject.transform.position.y);
        	//body.AddForce(transform.right * -vel);
            //gameObject.transform.position = new Vector2(gameObject.transform.position.x - vel, gameObject.transform.position.y);
        /*switch(dir) {
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
        }*/
    }

    private void OnCollisionEnter2D(Collision2D col) {
        canJump=true;
    }

    /*void OnTriggerEnter2D(Collider2D other)
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
        	GetComponent<Camera>().transform.position = new Vector3(-2.15f,-16.93f,-10);
        	gameObject.transform.position = new Vector3(-2.22f,-16.71f,0);
        	GetComponent<Camera>().transform.parent = gameObject.transform;
        }
        if (other.tag == "Player") {
        	GetComponent<Camera>().transform.parent = null;
        	GetComponent<Camera>().transform.position = new Vector3(0,0,-10);
        	gameObject.transform.position = new Vector3(-4.55f,-3.63f,0);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
    	conversation=0;
    	notification.SetActive(false);
    }*/

}

