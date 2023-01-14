using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject inventory;
    public Transform itemsParent;

    public GameObject blackBox;

    public List<GameObject> clothesList = new List<GameObject>();

    //public GameObject inventorySlotPrefab;

    Vector3 size = new Vector3(0.77f, 0.77f, 0.77f);

    public int inventorySpace = 6;


    public List<InventorySlot> inventoryList = new List<InventorySlot>();

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            //inventory.SetActive(!inventory.activeSelf);
        }
    }

    public void UpdateInventoryUI(GameObject inventorySlotPrefab) {
        //Instantiate item in Items Parent
        GameObject item = Instantiate(inventorySlotPrefab, itemsParent.transform.position, Quaternion.identity);
        item.transform.SetParent(itemsParent);

        item.GetComponent<InventorySlot>().isBuyabble = false;
        item.GetComponent<InventorySlot>().isSellable = true;

        item.GetComponent<RectTransform>().localScale = size;
    }
}
