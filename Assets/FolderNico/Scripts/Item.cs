using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite itemIcon;
    public int price;
    public int quantity;

    public Item(string name, Sprite icon, int price, int quantity = 1)
    {
        this.itemName = name;
        this.itemIcon = icon;
        this.price = price;
        this.quantity = quantity;
    }
}
