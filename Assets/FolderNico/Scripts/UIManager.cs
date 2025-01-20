using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Transform inventoryUI;
    public Transform shopUI;
    public GameObject itemUIPrefab;

    public void UpdateInventoryUI(Inventory inventory)
    {
        foreach (Transform child in inventoryUI)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in inventory.items)
        {
            GameObject newItemUI = Instantiate(itemUIPrefab, inventoryUI);
            newItemUI.GetComponentInChildren<Text>().text = $"{item.itemName} x{item.quantity}";
            newItemUI.GetComponentInChildren<Image>().sprite = item.itemIcon;
        }
    }

    public void UpdateShopUI(Shop shop)
    {
        foreach (Transform child in shopUI)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in shop.shopItems)
        {
            GameObject newItemUI = Instantiate(itemUIPrefab, shopUI);
            newItemUI.GetComponentInChildren<Text>().text = $"{item.itemName} - ${item.price}";
            newItemUI.GetComponentInChildren<Image>().sprite = item.itemIcon;
        }
    }
}
