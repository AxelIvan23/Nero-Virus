using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour
{
	[SerializeField]
	private Image heart;
	[SerializeField]
	private ManagerData data;
	[SerializeField]
	private Sprite[] heartState;
	private List<Image> hearts;
	private float hp;
    // Start is called before the first frame update
    void Awake()
    {   
        hearts = new List<Image>();
    	hp= data.data.HP;
        for (int i=0; i<data.data.TotalHP;i++) {
        	Image instance=Instantiate(heart, gameObject.transform.position,Quaternion.identity,gameObject.transform);
        	//instance.transform.position = new Vector3(gameObject.transform.position.x+10+i*(Screen.width*70/1080),0,0);
        	instance.GetComponent<RectTransform>().anchoredPosition = new Vector2(10+i*(Screen.width*70/1920)+(10*i),0);
        	if (hp>=0.5)
        		instance.sprite = heartState[1];
        	if (hp>=1)
        		instance.sprite = heartState[0];
        	if (hp<=0)
        		instance.sprite = heartState[2];
        	hp--;
        	hearts.Add(instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (data.data.HP!=hp) {
        	hp = data.data.HP;
        	OnHpChange();
        }
    }

    public void OnHpChange() {
        for (int i=0; i<data.data.TotalHP;i++) {
            Image instance=hearts[i];
            if (hp>=0.5)
                instance.sprite = heartState[1];
            if (hp>=1)
                instance.sprite = heartState[0];
            if (hp<=0)
                instance.sprite = heartState[2];
            hp--;
        }
    }
}
