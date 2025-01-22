using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStats : MonoBehaviour
{
    public PersonController personController;
    public Inventory inventory;
    public int upgradeLevel = 0; 
    public int speedUpgradeCost = 20;
    public int damageUpgradeCost = 40; 

    public void UpgradeSpeed()
    {
        if (personController == null)
        {
            Debug.LogError("playerSpeed no está asignado.");
            return;
        }

        if (inventory.HasEnoughMoney(speedUpgradeCost))
        {
            personController.speed += personController.speed * 0.01f;
            inventory.SpendMoney(speedUpgradeCost);
            upgradeLevel++;
            speedUpgradeCost += 4;
            Debug.Log($"Velocidad mejorada a {personController.speed}. Nivel: {upgradeLevel}. Costo siguiente: {speedUpgradeCost} monedas.");
        }
        else
        {
            Debug.LogWarning("No tienes suficientes monedas para mejorar la velocidad.");
        }
    }

    public void UpgradeDamage()
    {
        if (inventory == null)
        {
            Debug.LogError("inventory no está asignado.");
            return;
        }

        if (inventory.HasEnoughMoney(damageUpgradeCost))
        {
            personController.damage += 1;
            inventory.SpendMoney(damageUpgradeCost);
            upgradeLevel++;
            damageUpgradeCost += 20;
            Debug.Log($"Daño mejorado a {personController}. Nivel: {upgradeLevel}. Costo siguiente: {damageUpgradeCost} monedas.");
        }
        else
        {
            Debug.LogWarning("No tienes suficientes monedas para mejorar el daño.");
        }
    }

}