using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject upgradePanel;
    public Inventory inventory;
    public UpgradeStats upgradeStats;
    public TextMeshProUGUI cantidadDinero;
    public TextMeshProUGUI costoMejoraVelocidad;
    public TextMeshProUGUI costoMejoraDano;
    public TextMeshProUGUI nivel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            UpdateTimeScale();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            upgradePanel.SetActive(!upgradePanel.activeSelf);
            UpdateTimeScale();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            inventory.AddMoney(1000);
        }
        cantidadDinero.text = inventory.playerMoney.ToString();
        costoMejoraVelocidad.text = upgradeStats.speedUpgradeCost.ToString();
        costoMejoraDano.text = upgradeStats.damageUpgradeCost.ToString();
        nivel.text = upgradeStats.upgradeLevel.ToString();
    }

    private void UpdateTimeScale()
    {
        if (inventoryPanel.activeSelf || upgradePanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
