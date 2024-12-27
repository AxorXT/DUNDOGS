using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform inventoryPanel;
    public GameObject slotPrefab;

    private InventoryNode head;
    private InventoryNode tail;

    public void AddItem(string name, Sprite icon)
    {
        if (string.IsNullOrEmpty(name) || icon == null)
        {
            Debug.LogError("El nombre o el ícono del ítem no pueden ser nulos.");
            return;
        }

        InventoryNode newNode = new InventoryNode(name, icon);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.next = newNode;
            tail = newNode;
        }

        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        if (inventoryPanel == null)
        {
            Debug.LogError("inventoryPanel no está asignado.");
            return;
        }

        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        InventoryNode currentNode = head;
        while (currentNode != null)
        {
            GameObject slot = Instantiate(slotPrefab, inventoryPanel);
            SlotUI slotUI = slot.GetComponent<SlotUI>();

            if (slotUI != null)
            {
                slotUI.SetSlot(
                    currentNode.itemName,
                    currentNode.itemIcon,
                    () => Debug.Log($"Usando objeto: {currentNode.itemName}")
                );
            }
            else
            {
                Debug.LogError("El prefab no tiene un componente SlotUI.");
            }

            currentNode = currentNode.next;
        }
    }
}

public class InventoryNode
{
    public string itemName;
    public Sprite itemIcon;
    public InventoryNode next;

    public InventoryNode(string name, Sprite icon)
    {
        itemName = name;
        itemIcon = icon;
        next = null;
    }
}
