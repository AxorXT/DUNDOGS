using JetBrains.Annotations;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class InventorySaveSystem
{
    private static string savePath = Application.persistentDataPath + "/inventory.json";
    private static string savePathMoney = Application.persistentDataPath + "/money.json";

    public static void SaveInventory(List<Item> items, int inventory)
    {
        string json = JsonUtility.ToJson(new ItemListWrapper(items), true);
        File.WriteAllText(savePath, json);
        Debug.Log($"Inventario guardado en: {savePath}");

        string jsonM = JsonUtility.ToJson(inventory);
        File.WriteAllText(savePathMoney, jsonM);
        Debug.Log("Datos guardados en: " + savePathMoney);
    }

    public static List<Item> LoadInventory()
    {
        if (File.Exists(savePath) && File.Exists(savePathMoney))
        {
            Inventory inventory;
            string json = File.ReadAllText(savePath);
            ItemListWrapper itemList = JsonUtility.FromJson<ItemListWrapper>(json);
            
            string jsonM = File.ReadAllText(savePathMoney);
            inventory = JsonUtility.FromJson<Inventory>(jsonM);
            Debug.Log("Datos cargados: " + inventory.playerMoney);
            return itemList.items;

        }
        Debug.LogWarning("Archivo de inventario no encontrado, cargando inventario vacío.");
        return new List<Item>();
    }

    [System.Serializable]
    private class ItemListWrapper
    {
        public List<Item> items;

        public ItemListWrapper(List<Item> items)
        {
            this.items = items;
        }
    }
}
