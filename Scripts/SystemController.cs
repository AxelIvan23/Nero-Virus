using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : MonoBehaviour
{
	private int countLevelPart=0;
	private float position;
	private int mode;
	private float playerHP;
	private float playerMP;
	[SerializeField]
	private LevelRunGenerator level;
	public void modeConversation() {
		mode=2;
	}

	public void modeGame() {
		mode=0;
	}

	public void modeRunner() {
		mode=1;
		position=level.prefabs[0].atPosition;
	}
    // Start is called before the first frame update
    void Start()
    {
        modeRunner();
    }

    // Update is called once per frame
    void Update()
    {
        if (mode==1) {
        	gameObject.transform.position = new Vector3(gameObject.transform.position.x+0.01f,gameObject.transform.position.y,0);
        	if (countLevelPart < level.prefabs.Length) {
        		if (gameObject.transform.position.x > position-(level.prefabs[countLevelPart].atPosition/1.0f)) {
        			GameObject temp = Instantiate(level.prefabs[countLevelPart].prefabLevel, new Vector3(0,-100,0), Quaternion.identity);
        			temp.transform.parent = null;
        			temp.transform.position = new Vector3(position,-0.51f,0);
        			if (level.prefabs[countLevelPart].loop)
        				position = position+level.prefabs[countLevelPart].size.x;
        		}
        	}
        }
    }
}
