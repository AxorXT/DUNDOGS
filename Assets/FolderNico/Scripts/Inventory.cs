using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int playerMoney = 500; 

    private void Start()
    {
        LoadInventory();
    }

    public void AddItem(Item item)
    {
        Item existingItem = items.Find(i => i.itemName == item.itemName);
        if (existingItem != null)
        {
            existingItem.quantity += item.quantity;
        }
        else
        {
            items.Add(item);
        }
        SaveInventory();
    }

    public void RemoveItem(Item item)
    {
        Item existingItem = items.Find(i => i.itemName == item.itemName);
        if (existingItem != null)
        {
            existingItem.quantity -= item.quantity;
            if (existingItem.quantity <= 0)
                items.Remove(existingItem);
        }
        SaveInventory();
    }

    public bool HasEnoughMoney(int price)
    {
        return playerMoney >= price;
    }

    public void SpendMoney(int amount)
    {
        if (HasEnoughMoney(amount))
        {
            playerMoney -= amount;
        }
        else
        {
            Debug.LogWarning("Intento de gastar más dinero del disponible.");
        }
    }

    public void AddMoney(int amount)
    {
        playerMoney += amount;
    }

    public void SaveInventory()
    {
        InventorySaveSystem.SaveInventory(items, playerMoney);
    }

    public void LoadInventory()
    {
        items = InventorySaveSystem.LoadInventory();
    }
}
