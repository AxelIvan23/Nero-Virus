using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    private int num=0;
    [SerializeField]
    private ManagerData data;
    private Animator anim;

    void Start() {
    	anim = gameObject.GetComponent<Animator>();
    }

    void Update() {
    	if (data.data.dialogNum!=num) {
    		num=data.data.dialogNum;
    		setAnimation();
    	}   
    }

    public void setAnimation() {
    	anim.SetInteger("cinematic",num);
    }
}
