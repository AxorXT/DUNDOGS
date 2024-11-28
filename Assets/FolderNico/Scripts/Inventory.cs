using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public Transform inventoryPanel; // Panel donde se mostrarán los slots
    public GameObject slotPrefab; // Prefab del slot del inventario

    private InventoryNode head; // Nodo inicial de la lista
    private InventoryNode tail; // Nodo final para facilitar la inserción

    public void AddItem(string name, Sprite icon)
    {
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
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        InventoryNode currentNode = head;
        while (currentNode != null)
        {
            GameObject slot = Instantiate(slotPrefab, inventoryPanel);
            SlotUI slotUI = slot.GetComponent<SlotUI>();

            slotUI.SetSlot(
                currentNode.itemName,
                currentNode.itemIcon,
                () => Debug.Log($"Usando objeto: {currentNode.itemName}")
            );

            currentNode = currentNode.next;
        }
    }

}
