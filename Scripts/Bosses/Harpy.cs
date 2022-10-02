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
	public bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
    	anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        startTime = Time.time;
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
    	Debug.Log(attack);
    	switch (attack) {
    		case 0: gameObject.transform.position = new Vector3(1.167f*direction, Random.Range(-0.268f,0.0f),0);
    				anim.SetInteger("State",1);break;
    		case 1: gameObject.transform.position = new Vector3(1.167f*direction, 0.423f,0);
    				anim.SetInteger("State",2);StartCoroutine("Attack2Generate");break;
    		case 2: ;break;
    	}
    }

    public void Repeat() {
    	int num = Random.Range(0,5);
    	if (num==2 || num==3) 
    		Attack(Random.Range(0,3),Random.Range(0,2)*2-1);
    	else 
    		anim.SetInteger("state",4);
    }

    public void enableAttack() {
    	canAttack=true;
    	startTime=Time.time;
    }

    private IEnumerator Attack2Generate() {
    	AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
    	Debug.Log(clips[1].length);
    	
    	float num1 = Random.Range(0.02f,clips[1].length-0.02f);
    	float num2 = Random.Range(0.02f,clips[1].length-0.02f);

    	if (num2>num1) {
    		float temp = num2;
    		num2=num1;
    		num1=temp;
    	}

    	yield return new WaitForSeconds(num1);
    	Instantiate(bombs, gameObject.transform.position, Quaternion.identity, gameObject.transform.parent);
    }
}
