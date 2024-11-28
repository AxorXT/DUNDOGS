using UnityEngine;

[System.Serializable]
public class InventoryNode
{
    public string itemName; 
    public Sprite itemIcon; 
    public InventoryNode next; 

    public InventoryNode(string name, Sprite icon)
    {
        itemName = name;
        itemIcon = icon;
        next = null;
    }
}
