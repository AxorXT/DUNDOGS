using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public Inventory inventory; // Referencia al script de inventario
    public Sprite testSprite1; // Icono para el primer objeto
    public Sprite testSprite2; // Icono para el segundo objeto

    void Start()
    {
        // Agregar objetos al inventario con acciones personalizadas al hacer clic
        inventory.AddItem("Espada", testSprite1);
        inventory.AddItem("Escudo", testSprite2);
    }

    void Update()
    {
        // Agregar objetos al inventario dinámicamente al presionar teclas
        if (Input.GetKeyDown(KeyCode.A))
        {
            inventory.AddItem("Poción", testSprite1);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            inventory.AddItem("Arco", testSprite2);
        }
    }
}
