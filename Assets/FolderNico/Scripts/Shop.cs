using UnityEngine;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    [System.Serializable]
    public class ShopItem
    {
        public string itemName;
        public Sprite itemIcon;
        public int itemPrice;
    }

    public List<ShopItem> allItems;
    public Transform shopPanel;
    public GameObject slotPrefab;

    private List<ShopItem> displayedItems = new List<ShopItem>();

    void Start()
    {
        DisplayRandomItems();
    }

    void DisplayRandomItems()
    {
        foreach (Transform child in shopPanel)
        {
            Destroy(child.gameObject);
        }

        if (allItems.Count < 6)
        {
            Debug.LogError("No hay suficientes ítems en la lista para llenar la tienda.");
            return;
        }

        HashSet<int> selectedIndices = new HashSet<int>();
        while (selectedIndices.Count < 6)
        {
            int randomIndex = Random.Range(0, allItems.Count);
            selectedIndices.Add(randomIndex);
        }

        displayedItems.Clear();
        foreach (int index in selectedIndices)
        {
            ShopItem item = allItems[index];
            displayedItems.Add(item);

            GameObject slot = Instantiate(slotPrefab, shopPanel);
            SlotUI slotUI = slot.GetComponent<SlotUI>();

            if (slotUI != null)
            {
                slotUI.SetSlot(
                    item.itemName,
                    item.itemIcon,
                    () => Debug.Log($"Comprando ítem: {item.itemName} por {item.itemPrice} monedas.")
                );
            }
            else
            {
                Debug.LogError("El prefab del slot no tiene un componente SlotUI.");
            }
        }
    }
}
