using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image icon; // Imagen para el ícono del objeto
    public Text itemName; // Texto para el nombre del objeto
    private Button button; // Referencia al botón

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
