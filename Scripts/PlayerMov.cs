using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
	private int dir = 0;
	public float vel;
    public bool canJump = true;
	//private int conversation=0;
    private int state=0;
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
            anim.SetInteger("State",2);
            //transform.Translate(Vector3.up * 2.6f * Time.deltaTime, Space.World);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(velocity.x/1.8f, 2.8f), ForceMode2D.Impulse);
            canJump=false;
             //gameObject.GetComponent<Renderer>().flipX = false;
        }
        /*if (Input.GetKeyDown(KeyCode.Space)) {
        	if (conversation>0) {
	        	dialogSystem.enabled = true;
	        	dialogSystem.StartConversation(conversation-1);
        	}
        }*/
    }

    public void setState(){
        anim.SetInteger("State",0);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (canJump!=true) 
            anim.SetInteger("State",3);
        canJump=true;
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Daño") {
        	notification.SetActive(true);
        	conversation=1;
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

