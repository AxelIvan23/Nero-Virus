using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelObject", order = 1)]
public class LevelRunGenerator : ScriptableObject
{
	[System.Serializable]
	public struct LevelData {
		public GameObject prefabLevel;
		public bool loop;
		public float atPosition;
		public Vector2 size;
	}
	[SerializeField]
    public LevelData[] prefabs;

    public void startLevel() {
    	
    }
}
