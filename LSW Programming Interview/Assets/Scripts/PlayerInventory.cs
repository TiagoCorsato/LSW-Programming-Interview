using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject inventory;
    public Transform itemsParent;
    //public GameObject inventorySlotPrefab;


    public List<InventorySlot> inventoryList = new List<InventorySlot>();

    void Start()
    {

    }

    void Update()
    {

    }

    public void UpdateInventoryUI(GameObject inventorySlotPrefab)
    {
        //Instantiate item in Items Parent
        GameObject item = Instantiate(inventorySlotPrefab, itemsParent.transform.position, Quaternion.identity);
        item.transform.SetParent(itemsParent);

        item.GetComponent<InventorySlot>().isBuyabble = false;
        item.GetComponent<InventorySlot>().isSellable = true;
    }
}
