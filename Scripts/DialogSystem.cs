using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem : MonoBehaviour
{
	[SerializeField]
	private DialogMessages[] Dialogs;
	private int Num=0;
	private int flag=0;
	private int decision=1;
	private int ConversationNum;
	private int MinMax=3;

	[SerializeField]
	private GameObject ChatPanel;
    [SerializeField]
    private GameObject LifePanel;
	[SerializeField]
	private TextMeshProUGUI ChatName;
	[SerializeField]
	private TextMeshProUGUI ChatText;
	[SerializeField]
	private GameObject DecisionsPanel;
	[SerializeField]
	private GameObject[] Player;
    [SerializeField]
    private ManagerData data;
    [SerializeField]
    private GameObject[] enableObjects;
	//[SerializeField]
	//private ChangeClothes ClothesSystem;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
    		Num++;
            data.data.dialogNum=Num;
    		Dialog(Num);
        }
    }

    public void StartConversation(int ConverNum) {
    	Num=0;
    	decision=1;
    	flag=0;
    	ChatPanel.SetActive(true);
    	if (data.data.Player==1)
            Player[1].GetComponent<PlayerMov>().enabled = false;
        if (data.data.Player==0)
            Player[0].GetComponent<SimplePlayerController>().enabled = false;
    	ConversationNum = ConverNum;
    	Dialog(Num);
    }
    public void Dialog(int conversation) {
    	if (conversation < Dialogs[ConversationNum].messages.Length) {
	    	//ChatImage.sprite = Dialogs[ConversationNum].messages[conversation].emotion;
	    	ChatText.text = Dialogs[ConversationNum].messages[conversation].message;
            ChatName.text = Dialogs[ConversationNum].messages[conversation].name;
	    } else {
	    	EndConversation();
	    }
    }
    public void EndConversation() {
        ChatPanel.SetActive(false);
        LifePanel.SetActive(true);
        if (data.data.Player==1)
    	    Player[1].GetComponent<PlayerMov>().enabled = true;
        if (data.data.Player==0)
            Player[0].GetComponent<SimplePlayerController>().enabled = true;
        if (enableObjects.Length>0) {
            for (int i=0; i<enableObjects.Length; i++) {
                enableObjects[i].SetActive(true);
            }
        }
        gameObject.GetComponent<DialogSystem>().enabled = false;
    } 
}
