using UnityEngine;

[CreateAssetMenu(fileName="ManagerData", menuName="Data", order=3)]
public class ManagerData : ScriptableObject
{
    [System.Serializable]
    public struct Data {
    	public int Player; 
    	public int MaxHP;
    	public float SavedHP; 
    	public float HP; 
    	public int dialogNum;
    	public int mode;
    	public string lastScene;
    	public Vector3 lastPos;
    }
    [SerializeField]
    public Data data;
}
