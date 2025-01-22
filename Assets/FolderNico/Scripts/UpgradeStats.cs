using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStats : MonoBehaviour
{
    public PersonController playerSpeed;
    public Inventory inventory;
    public int playerDamage = 10; 
    public int upgradeLevel = 0; 
    public int speedUpgradeCost = 10;
    public int damageUpgradeCost = 20; 

    public void UpgradeSpeed()
    {
        if (playerSpeed == null)
        {
            Debug.LogError("playerSpeed no est� asignado.");
            return;
        }

        if (inventory.HasEnoughMoney(speedUpgradeCost))
        {
            playerSpeed.speed += playerSpeed.speed * 0.01f;
            inventory.SpendMoney(speedUpgradeCost);
            upgradeLevel++;
            speedUpgradeCost += 2;
            Debug.Log($"Velocidad mejorada a {playerSpeed.speed}. Nivel: {upgradeLevel}. Costo siguiente: {speedUpgradeCost} monedas.");
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
            Debug.LogError("inventory no est� asignado.");
            return;
        }

        if (inventory.HasEnoughMoney(damageUpgradeCost))
        {
            playerDamage += 5;
            inventory.SpendMoney(damageUpgradeCost);
            upgradeLevel++;
            damageUpgradeCost += 5;
            Debug.Log($"Da�o mejorado a {playerDamage}. Nivel: {upgradeLevel}. Costo siguiente: {damageUpgradeCost} monedas.");
        }
        else
        {
            Debug.LogWarning("No tienes suficientes monedas para mejorar el da�o.");
        }
    }

}