using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMov : MonoBehaviour
{
	private int dir = 0;
	public float vel;
    public float jumpvel;
    public int attackType;

    public bool canJump = true;
    public bool canBeHit = true;
    public bool canAttack = true;
	//private int conversation=0;
    private int state=0;
	private Animator anim;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private float hp;
    public int attack=0;
    public Material normal;
    public Material glitch;

    [SerializeField]
    private ManagerData data;
    [SerializeField]
    private GameObject gameEnd;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        body = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.GetComponent<Renderer>().material = normal;
        if (data.data.mode==1) 
            anim.SetInteger("State",1);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Input: "+Input.GetAxis("Horizontal"));
        Vector2 velocity = new Vector2(Input.GetAxis("Horizontal")*vel,0); 
        //body.AddForce(transform.right * vel);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x+(velocity.x*Time.deltaTime),gameObject.transform.position.y,0);
        if (Input.GetKeyDown ("space") && canJump==true ){
            anim.SetInteger("State",2);
            //transform.Translate(Vector3.up * 2.6f * Time.deltaTime, Space.World);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(velocity.x/1.8f, jumpvel), ForceMode2D.Impulse);
            canJump=false;
             //gameObject.GetComponent<Renderer>().flipX = false;
        }
        if (Input.GetButtonDown ("Attack") && canAttack==true) {
            attack++;
            anim.SetInteger("Attack",attack);
            if (attack>2) {
                canAttack=false;
            }
        }
        if (data.data.mode==0) {
            if (Input.GetAxis("Horizontal")>0) {
                spriteRenderer.flipX = false;
                anim.SetInteger("State",1);
            } else if (Input.GetAxis("Horizontal")<0) {
                spriteRenderer.flipX = true;
                anim.SetInteger("State",1);
            } else 
                anim.SetInteger("State",0);
        }
    }

    public void setState(string paramss){
        string[] param = paramss.Split(',');
        if (data.data.mode == 1 && param[0]=="State")
            state=1;
        else
            state=0;
        anim.SetInteger(param[0],state);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            canJump=true;
            anim.SetInteger("State",3);
        }
    }

    private void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            canJump=false;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hit" && canBeHit==true) {
            canBeHit=false;
        	data.data.HP=data.data.HP-0.5f;
            if (data.data.HP<=0)
                gameOver();
            else
                StartCoroutine(coolDown((result)=>{canBeHit=result;},1.5f));
        }
        if (other.tag == "Message") {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKey ("e")) {
            Debug.Log("triggerStay");
            if (other.tag == "Message") {
                other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                other.gameObject.GetComponent<DialogSystem>().enabled = true;
                other.gameObject.GetComponent<Cinematic>().enabled = true;
                other.gameObject.GetComponent<DialogSystem>().StartConversation(0);
            }
            if (other.tag == "Terminal") {
                SceneManager.LoadScene("Level1 1");
            }
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Message" || other.tag == "Terminal") {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public IEnumerator coolDown(System.Action<bool> callback, float time) {
        yield return new WaitForSeconds(time);
        if (callback != null) callback(true);
    }

    private void gameOver() {
        gameObject.GetComponent<Renderer>().material = glitch;
        anim.SetInteger("State",5);
        anim.SetBool("gameEnd",true);
        gameEnd.SetActive(true);
    }

    public void resetAttack(int num) {
        if (attack==num) {
            attack=0;
            anim.SetInteger("Attack",attack);
            StartCoroutine(coolDown((result)=>{canAttack=result;},0.6f));
        }
    }

    public void resetPlayer() {
        hp = data.data.HP;

    }
}

