using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject upgradePanel;
    public Inventory inventory;
    public TextMeshProUGUI cantidadDinero;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            upgradePanel.SetActive(!upgradePanel.activeSelf); 
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            inventory.AddMoney(250);
        }
        cantidadDinero.text = inventory.playerMoney.ToString();

    }
}
