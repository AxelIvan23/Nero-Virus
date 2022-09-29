using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelObject", order = 1)]
public class LevelRunGenerator : ScriptableObject
{
	[System.Serializable]
	public struct MessageData {
		public string messages;
		public Sprite emotion;
		public string[] decision;
	}
	[SerializeField]
    public MessageData[] messages;

    public void startLevel() {
    	
    }
}
