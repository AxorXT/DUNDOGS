using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image icon; // Imagen para el �cono del objeto
    public Text itemName; // Texto para el nombre del objeto
    private Button button; // Referencia al bot�n

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void SetSlot(string name, Sprite itemIcon, System.Action onClickAction = null)
    {
        itemName.text = name;
        icon.sprite = itemIcon;
        icon.enabled = itemIcon != null;

        if (onClickAction != null)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => onClickAction());
        }
    }
}
