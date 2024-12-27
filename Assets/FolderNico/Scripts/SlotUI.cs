using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Text itemNameText;
    public Image itemIconImage;
    public Button buyButton;

    public void SetSlot(string itemName, Sprite itemIcon, System.Action onBuy)
    {
        itemNameText.text = itemName;
        itemIconImage.sprite = itemIcon;
        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(() => onBuy());
    }
}
