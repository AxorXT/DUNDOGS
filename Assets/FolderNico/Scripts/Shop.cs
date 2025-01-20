using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Item> shopItems = new List<Item>();
    private ShopLoader shopLoader;

    private void Start()
    {
        shopLoader = GetComponent<ShopLoader>();
        shopItems = shopLoader.LoadShopItems();
    }

    public void BuyItem(Item item, Inventory inventory)
    {
        if (inventory.HasEnoughMoney(item.price))
        {
            inventory.SpendMoney(item.price);
            inventory.AddItem(item); 
            Debug.Log($"Has comprado {item.itemName} por {item.price} monedas. Dinero restante: {inventory.playerMoney}");
        }
        else
        {
            Debug.Log("No tienes suficiente dinero.");
        }
    }


    public void SellItem(Item item, Inventory inventory)
    {
        inventory.RemoveItem(item);
        Debug.Log($"Has vendido {item.itemName}");
    }
}
