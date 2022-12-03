using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
	public float time=0;
	public int band=0;
	public void Start() {
		if (band==1) {
			destroyParent();
		}
	}
    public void destroyParent() {
    	Destroy(gameObject,time);
    }
}
