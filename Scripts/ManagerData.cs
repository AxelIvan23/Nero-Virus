using UnityEngine;

[CreateAssetMenu(fileName="ManagerData", menuName="Data", order=3)]
public class ManagerData : ScriptableObject
{
    [System.Serializable]
    public struct Data {
    	public int TotalHP;
    	public float HP; 
    	public int dialogNum;
    }
    [SerializeField]
    public Data data;
}
