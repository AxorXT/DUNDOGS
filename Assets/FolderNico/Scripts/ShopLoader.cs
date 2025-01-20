using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShopLoader : MonoBehaviour
{
    public string shopItemsFileName = "shopItems.txt";
    public int numberOfItemsInShop = 5;

    public List<Item> LoadShopItems()
    {
        List<Item> availableItems = new List<Item>();
        string filePath = Application.dataPath + "/" + shopItemsFileName;

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 3)
                {
                    string itemName = parts[0];
                    int price = int.Parse(parts[1]);
                    Sprite icon = Resources.Load<Sprite>(parts[2]);

                    availableItems.Add(new Item(itemName, icon, price));
                }
            }
        }
        else
        {
            Debug.LogError($"Archivo {shopItemsFileName} no encontrado.");
        }

        return GetRandomShopItems(availableItems);
    }

    private List<Item> GetRandomShopItems(List<Item> availableItems)
    {
        List<Item> selectedItems = new List<Item>();
        int itemCount = Mathf.Min(numberOfItemsInShop, availableItems.Count);

        while (selectedItems.Count < itemCount)
        {
            int randomIndex = Random.Range(0, availableItems.Count);
            Item randomItem = availableItems[randomIndex];

            if (!selectedItems.Contains(randomItem))
            {
                selectedItems.Add(randomItem);
            }
        }

        return selectedItems;
    }
}
