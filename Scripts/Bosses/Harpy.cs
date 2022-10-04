using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpy : MonoBehaviour
{
	private Animator anim;
	[SerializeField]
	private float timeToAttack;
	[SerializeField]
	private float timeVulnerable;
	[SerializeField]
	private GameObject bombs;
	private int animation;
	private float startTime; 
	private AnimationClip[] clips;
	public bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
    	anim = gameObject.transform.GetComponent<Animator>();
        startTime = Time.time;
        clips = anim.runtimeAnimatorController.animationClips;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time-startTime>timeToAttack && canAttack==true) {
        	canAttack=false;
        	Attack(Random.Range(0,3),Random.Range(0,2)*2-1);
        }
    }

    public void Attack(int attack, int direction) {
    	attack=1;
    	Debug.Log(direction);
    	gameObject.transform.parent.rotation = Quaternion.Euler(0,90*(1+direction),0);
    	switch (attack) {
    		case 0: gameObject.transform.parent.position = new Vector3(gameObject.transform.parent.parent.position.x+(1.167f*direction), Random.Range(-0.268f,0.0f),0);
    				anim.SetInteger("State",1);break;
    		case 1: gameObject.transform.parent.position = new Vector3(gameObject.transform.parent.parent.position.x+(1.167f*direction), 0.423f,0);
    				anim.SetInteger("State",2);StartCoroutine("Attack2Generate");break;
    		case 2: ;break;
    		case 3: ;break;
    	}
    }

    public void Repeat() {
    	int num = Random.Range(0,5);
    	if (num==2 || num==3) 
    		Attack(Random.Range(0,3),Random.Range(0,2)*2-1);
    	else  {
    		anim.SetInteger("state",4);
    	}
    }

    public void enableAttack() {
    	canAttack=true;
    	startTime=Time.time;
    }

    private IEnumerator Attack2Generate() {
    	Debug.Log(clips[1]);
    	
    	float num1 = Random.Range(0.55f,(clips[1].length/2.0f)-0.4f);
    	float num2 = Random.Range(0.55f,(clips[1].length/2.0f)-0.4f);
    	Debug.Log("Random num1: "+num1);
    	Debug.Log("Random num2: "+num2);

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
    	Debug.Log("Vulnerable");
    	gameObject.transform.parent.position = new Vector3(gameObject.transform.parent.position.x,0.12f,0);
    	anim.SetInteger("State",6);
    	yield return new WaitForSeconds(clips[4].length);
    	anim.SetInteger("State",7);
    	yield return new WaitForSeconds(timeVulnerable);
    	anim.SetInteger("State",0);
    	yield return new WaitForSeconds(clips[4].length);
    	enableAttack();
    }
}
