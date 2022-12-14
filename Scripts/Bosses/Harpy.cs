using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Harpy : MonoBehaviour
{
	private Animator anim;
	[SerializeField]
	private float timeToAttack;
	[SerializeField]
	private float timeVulnerable;
	[SerializeField]
	private GameObject bombs;
    [SerializeField]
    private TextMeshProUGUI enemyName;
    [SerializeField]
    private Image HpBar;
    [SerializeField]
    private Material Glitch;
	private int animation;
    private int attacks;
	private float startTime; 
    private float sizeX; 
	private AnimationClip[] clips;
    private bool canBeHit = true;
	public bool canAttack = true;
    public bool won = false;
    public float EnemyHp;
    private float hp;
    // Start is called before the first frame update
    void Start()
    {
    	anim = gameObject.transform.GetComponent<Animator>();
        startTime = Time.time+1.0f;
        clips = anim.runtimeAnimatorController.animationClips;
        enemyName.name = "Moon Harpy";
        sizeX=HpBar.GetComponent<RectTransform>().sizeDelta.x;
        hp = EnemyHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time-startTime>timeToAttack && canAttack==true && won==false) {
        	canAttack=false;
        	Attack(Random.Range(0,2),Random.Range(0,2)*2-1);
        }
    }

    public void Attack(int attack, int direction) {
    	//attack=1;
    	Debug.Log(direction);
        Debug.Log("Attack: "+ attack);
    	gameObject.transform.parent.rotation = Quaternion.Euler(0,90*(1+direction),0);
    	switch (attack) {
    		case 0: gameObject.transform.parent.position = new Vector3(gameObject.transform.parent.parent.position.x+(1.167f*direction), Random.Range(-0.268f,0.0f),0);
    				anim.SetInteger("State",1);attacks=0;break;
    		case 1: gameObject.transform.parent.position = new Vector3(gameObject.transform.parent.parent.position.x+(1.167f*direction), 0.423f,0);
    				anim.SetInteger("State",2);attacks=1;StartCoroutine("Attack2Generate");break;
    		case 2: ;break;
    		case 3: ;break;
    	}
    }

    public IEnumerator Repeat() {
    	int num = Random.Range(0,5);
        Debug.Log("Num: "+num);
    	if (num==2 || num==3)  {
            anim.SetInteger("State",0);
            yield return new WaitForSeconds(0.5f);
    		Attack(attacks,Random.Range(0,2)*2-1);
        }
    	else  {
    		StartCoroutine("Vulnerable");
    	}
    }

    public void enableAttack() {
    	canAttack=true;
    	startTime=Time.time;
    }

    private IEnumerator Attack2Generate() {
    	//Debug.Log(clips[1]);
    	
    	float num1 = Random.Range(0.55f,(clips[1].length/2.0f)-0.4f);
    	float num2 = Random.Range(0.55f,(clips[1].length/2.0f)-0.4f);

    	if (num1>num2) {
    		float temp = num2;
    		num2=num1;
    		num1=temp;
    	}

    	yield return new WaitForSeconds(num1);
    	Instantiate(bombs, gameObject.transform.position, Quaternion.identity, gameObject.transform.parent.parent);
    	yield return new WaitForSeconds(num2-num1);
    	Instantiate(bombs, gameObject.transform.position, Quaternion.identity, gameObject.transform.parent.parent);
    }

    public IEnumerator Vulnerable() {
        Debug.Log("Entraste?");
    	gameObject.transform.parent.position = new Vector3(gameObject.transform.parent.position.x,0.12f,0);
    	anim.SetInteger("State",6);
    	yield return new WaitForSeconds(clips[4].length);
    	anim.SetInteger("State",7);
    	yield return new WaitForSeconds(timeVulnerable);
    	anim.SetInteger("State",0);
    	yield return new WaitForSeconds(clips[4].length);
    	enableAttack();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hit" || other.tag=="Damage" && canBeHit==true) {
            canBeHit=false;
            hp=hp-1f;
            float porcentaje = hp / EnemyHp;
            HpBar.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX*porcentaje,HpBar.GetComponent<RectTransform>().sizeDelta.y);
            if (hp<=0) {
                win();
                hp=0;
            }
            else
                StartCoroutine(coolDown((result)=>{canBeHit=result;},0.2f));
        }
    }

    public IEnumerator coolDown(System.Action<bool> callback, float time) {
        yield return new WaitForSeconds(time);
        if (callback != null) callback(true);
    }

    public void win() {
        won=true;
        transform.GetChild(0).gameObject.SetActive(true);
        gameObject.GetComponent<Renderer>().material = Glitch;
        anim.SetInteger("State",8);
    }
}
