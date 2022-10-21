using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogObject", order = 1)]
public class DialogMessages : ScriptableObject
{
	[System.Serializable]
	public struct MessageData {
		public string message;
		public string name;
		public AudioClip sound;
		public string[] decision;
	}
	[SerializeField]
    public MessageData[] messages;
}
