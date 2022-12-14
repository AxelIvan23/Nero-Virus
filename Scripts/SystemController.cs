using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : MonoBehaviour
{
	private int countLevelPart=0;
	private float position;
    [SerializeField]
	private int mode;
    private int dialogNum;
	private float playerHP;
	private float playerMP;
    public float delay;
    public bool cinemachine;

    [SerializeField]
    private GameObject[] Characters;
    [SerializeField]
    private GameObject levelContainer;
    [SerializeField]
    private AudioClip[] audioClipArray;
	[SerializeField]
	private LevelRunGenerator level;
    [SerializeField]
    private DialogSystem dialogSystem;
    [SerializeField]
    private ManagerData data;


	public IEnumerator modeConversation(int clip, int conversation, float time) {
		mode=2;
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<AudioSource>().clip = audioClipArray[0];
        gameObject.GetComponent<AudioSource>().Play();
        dialogSystem.StartConversation(conversation);
        //gameObject.GetComponent<AudioSource>().PlayOneShot(audioClipArray[clip]);
	}

	public void modeGame() {
		mode=0;
        gameObject.GetComponent<AudioSource>().clip = audioClipArray[0];
        gameObject.GetComponent<AudioSource>().Play();
	}

	public void modeRunner(int clip) {
		mode=1;
		position=level.prefabs[0].atPosition;
        gameObject.GetComponent<AudioSource>().clip = audioClipArray[1];
        gameObject.GetComponent<AudioSource>().Play();
        //gameObject.GetComponent<AudioSource>().PlayOneShot(audioClipArray[clip]);
        StartCoroutine("temp");
	}
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = 1.0f;
        data.data.mode=mode;
        for (int i=0;i<Characters.Length;i++) {
            if (i==data.data.Player) {
                Characters[i].SetActive(true);
                Transform follow = transform.GetChild(0);
                transform.GetChild(0).SetParent(Characters[i].transform);
                follow.localPosition = new Vector3(0,0,0);
            }
        }
        if (mode==2) {
            StartCoroutine(modeConversation(0,0,delay));
        } else if (mode==1) {
            modeRunner(0);
        } else {
            modeGame();
        }
    }

    void Awake() {
        data.data.dialogNum=0;
    }

    // Update is called once per frame
    void Update()
    {
        if (data.data.mode!=mode) {
            mode=data.data.mode;
            if (data.data.mode==1)
                modeRunner(0);
        }
        if (mode==1) {
        	gameObject.transform.position = new Vector3(gameObject.transform.position.x+1.55f*Time.deltaTime,gameObject.transform.position.y,0);
        	if (countLevelPart < level.prefabs.Length) {
        		if (gameObject.transform.position.x > position-(level.prefabs[countLevelPart].atPosition/1.0f)) {
        			GameObject temp = Instantiate(level.prefabs[countLevelPart].prefabLevel, new Vector3(0,-100,0), Quaternion.identity);
        			temp.transform.parent = null;
        			temp.transform.position = new Vector3(position,-0.51f,0);
                    temp.transform.parent = levelContainer.transform;

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
