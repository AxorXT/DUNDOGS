using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemIcon;
    public int quantity;

    public Item(string name, Sprite icon = null, int price = 0, int quantity = 1)
    {
        this.itemName = name;
        this.itemIcon = icon;
        this.quantity = quantity;
    }

}
