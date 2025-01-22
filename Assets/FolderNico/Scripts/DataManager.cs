using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private string saveFilePath;

    [System.Serializable]
    public class SaveData
    {
        public List<ItemData> items;
        public float speed;
        public int damage;
        public int playerMoney;
        public int upgradeLevel;
        public int speedUpgradeCost;
        public int damageUpgradeCost;
    }

    [System.Serializable]
    public class ItemData
    {
        public string itemName;
        public int quantity;

        public ItemData(string name, int quantity)
        {
            this.itemName = name;
            this.quantity = quantity;
        }
    }

    public Inventory inventory;
    public UpgradeStats upgradeStats;
    public PersonController personController;

    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "gameData.json");

        inventory = GetComponent<Inventory>();
        upgradeStats = GetComponent<UpgradeStats>();
        PersonController personController = GetComponent<PersonController>();

        if (inventory == null || upgradeStats == null)
        {
            Debug.LogError("Faltan componentes Inventory o UpgradeStats en este GameObject.");
            return;
        }

        LoadGameData();
    }

    public void SaveGameData()
    {
        SaveData saveData = new SaveData
        {
            items = new List<ItemData>(),
            playerMoney = inventory.playerMoney,
            speed = personController.speed,
            damage = personController.damage,
            upgradeLevel = upgradeStats.upgradeLevel,
            speedUpgradeCost = upgradeStats.speedUpgradeCost,
            damageUpgradeCost = upgradeStats.damageUpgradeCost
        };

        foreach (var item in inventory.items)
        {
            saveData.items.Add(new ItemData(item.itemName, item.quantity));
        }

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Datos guardados en: " + saveFilePath);
    }

    public void LoadGameData()
    {
        if (!File.Exists(saveFilePath))
        {
            Debug.LogWarning("No se encontró un archivo de guardado. Comenzando un nuevo juego.");
            return;
        }

        string json = File.ReadAllText(saveFilePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        inventory.playerMoney = saveData.playerMoney;
        inventory.items.Clear();
        foreach (var itemData in saveData.items)
        {
            inventory.items.Add(new Item(itemData.itemName, null, 0, itemData.quantity));
        }

        personController.speed = saveData.speed;
        personController.damage = saveData.damage;
        upgradeStats.upgradeLevel = saveData.upgradeLevel;
        upgradeStats.speedUpgradeCost = saveData.speedUpgradeCost;
        upgradeStats.damageUpgradeCost = saveData.damageUpgradeCost;

        Debug.Log("Datos cargados desde: " + saveFilePath);
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }
}
