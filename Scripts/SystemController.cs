using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : MonoBehaviour
{
	private int countLevelPart=0;
	private float position;
	private int mode;
    private int dialogNum;
	private float playerHP;
	private float playerMP;
    [SerializeField]
    private AudioClip[] audioClipArray;
	[SerializeField]
	private LevelRunGenerator level;
    [SerializeField]
    private DialogSystem dialogSystem;

	public void modeConversation(int clip, int conversation) {
		mode=2;
        dialogSystem.StartConversation(conversation);
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClipArray[clip]);
	}

	public void modeGame() {
		mode=0;
	}

	public void modeRunner(int clip) {
		mode=1;
		position=level.prefabs[0].atPosition;
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClipArray[clip]);
        StartCoroutine("temp");
	}
    // Start is called before the first frame update
    void Start()
    {
        modeConversation(0,0);
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

    public IEnumerator temp() {
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<AudioSource>().volume = 1.0f;
    }
}
