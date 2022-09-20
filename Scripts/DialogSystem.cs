using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	private Image ChatImage;
	[SerializeField]
	private Text ChatText;
	[SerializeField]
	private GameObject DecisionsPanel;
	[SerializeField]
	private Text[] ChatDecisions;
	[SerializeField]
	private Text[] StorePanel;
	[SerializeField]
	private GameObject Player;
	//[SerializeField]
	//private ChangeClothes ClothesSystem;
    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.RightArrow)) {
    		if (decision<3)
    			decision=decision+1;
    		for (int i=0;i<3;i++) {
    			if (decision-1==i)
    				ChatDecisions[i].fontStyle = FontStyle.Bold;
    			else
    				ChatDecisions[i].fontStyle = FontStyle.Normal;
    		}
    	}
    	if (Input.GetKeyDown(KeyCode.LeftArrow)) {
    		if (decision>1)
    			decision=decision-1;
    		for (int i=0;i<3;i++) {
    			if (decision-1==i)
    				ChatDecisions[i].fontStyle = FontStyle.Bold;
    			else
    				ChatDecisions[i].fontStyle = FontStyle.Normal;
    		}
    	}
        if (Input.GetKeyDown(KeyCode.Space)) {
        	if (flag==1) {
        		Debug.Log(ChatDecisions[decision-1].text);
        		if (ChatDecisions[decision-1].text == "Buy!")
        			decision = 3;
        		if (ChatDecisions[decision-1].text == "Customize!") {
        			/*ChatPanel.SetActive(false);
			    	gameObject.GetComponent<DialogSystem>().enabled = false;*/
			    	StartConversation(2);
        		}
        		if (ChatDecisions[decision-1].text == "Normal costume") {
        			//ClothesSystem.CustomizeAnimation(0,0,0);
        			decision = 3;
        		}
        		if (ChatDecisions[decision-1].text == "Kung Fu Costume") {
        			//ClothesSystem.CustomizeAnimation(0,1,0);
        			decision = 3;
        		}
        		if (ChatDecisions[decision-1].text == "close") {
        			Num++;
        			Dialog(Num);
        		}
        	}
        	else {
        		Num++;
        		Dialog(Num);
        	}
        }
    }

    public void StartConversation(int ConverNum) {
    	Num=0;
    	decision=1;
    	flag=0;
    	ChatPanel.SetActive(true);
    	Player.GetComponent<PlayerMov>().enabled = false;
    	ConversationNum = ConverNum;
    	ChatDecisions[0].fontStyle = FontStyle.Bold;
    	ChatDecisions[1].fontStyle = FontStyle.Normal;
    	ChatDecisions[2].fontStyle = FontStyle.Normal;
    	Dialog(Num);
    }
    public void Dialog(int conversation) {
    	if (conversation < Dialogs[ConversationNum].messages.Length) {
	    	ChatImage.sprite = Dialogs[ConversationNum].messages[conversation].emotion;
	    	ChatText.text = Dialogs[ConversationNum].messages[conversation].message;
	    	if (Dialogs[ConversationNum].messages[conversation].decision.Length > 0) {
	    		ChatDecisions[0].text = Dialogs[ConversationNum].messages[conversation].decision[0];
	    		ChatDecisions[1].text = Dialogs[ConversationNum].messages[conversation].decision[1];
	    		ChatDecisions[2].text = Dialogs[ConversationNum].messages[conversation].decision[2];
	    		DecisionsPanel.SetActive(true);
	    		flag=1;
	    	} else {
	    		DecisionsPanel.SetActive(false);
	    	}
	    } else {
	    	EndConversation();
	    }
    }
    public void EndConversation() {
    	ChatPanel.SetActive(false);
    	Player.GetComponent<PlayerMov>().enabled = true;
    	gameObject.GetComponent<DialogSystem>().enabled = false;
    }
}
