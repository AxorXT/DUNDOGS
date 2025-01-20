using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Shop shop;
    public Inventory playerInventory;
    public UIManager uiManager;

    private void Start()
    {
        uiManager.UpdateInventoryUI(playerInventory);
        uiManager.UpdateShopUI(shop);
    }

    public void BuyItem(int itemIndex)
    {
        if (itemIndex < shop.shopItems.Count)
        {
            Item itemToBuy = shop.shopItems[itemIndex];
            shop.BuyItem(itemToBuy, playerInventory);
            uiManager.UpdateInventoryUI(playerInventory);
        }
    }

    public void SellItem(int itemIndex)
    {
        if (itemIndex < playerInventory.items.Count)
        {
            Item itemToSell = playerInventory.items[itemIndex];
            shop.SellItem(itemToSell, playerInventory);
            uiManager.UpdateInventoryUI(playerInventory);
        }
    }
}
