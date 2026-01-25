using UnityEngine;


public class ItemPickable : MonoBehaviour, Ipickable
{
    public ItemsSO itemScriptableObject;
    public PlayerInventory inventory;

    [Header("Sonido")]
    public string sonidoPick; 

    public void PickItem()
    {
        if (!string.IsNullOrEmpty(sonidoPick))
            AudioManager.Instance.Play(sonidoPick);

        inventory = FindObjectOfType<PlayerInventory>(); 
        if (inventory.inventoryList.Count < inventory.maxCapacity)
        {
            inventory.AgregarObjeto(itemScriptableObject);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No tienes espacio en el inventario");
        }
    }
}