using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "ScriptableObjects/Inventory/Item")]
public class Item : ScriptableObject
{
    public string ItemName = "New Item";
    public Sprite Icon = null;
    public bool isDefaultItem = false;



}
