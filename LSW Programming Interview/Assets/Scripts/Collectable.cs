using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    PlayerInventory playerInventory;

    public GameObject slotPrefab;

    void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    public void ColectItem()
    {
        playerInventory.UpdateInventoryUI(slotPrefab);
        playerInventory.inventoryList.Add(slotPrefab.GetComponent<InventorySlot>());
        Destroy(this.gameObject);
    }
}
