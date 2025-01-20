using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class InventorySaveSystem
{
    private static string savePath = Application.persistentDataPath + "/inventory.json";

    public static void SaveInventory(List<Item> items)
    {
        string json = JsonUtility.ToJson(new ItemListWrapper(items), true);
        File.WriteAllText(savePath, json);
        Debug.Log($"Inventario guardado en: {savePath}");
    }

    public static List<Item> LoadInventory()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            ItemListWrapper itemList = JsonUtility.FromJson<ItemListWrapper>(json);
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
