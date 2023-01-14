using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInventory : MonoBehaviour
{
    public GameObject inventory;
    public Transform itemsParent;

    public GameObject blackBox;

    public GameObject alert_space;
    public GameObject alert_cost;
    public Transform alertPosition;

    public List<GameObject> clothesList = new List<GameObject>();

    //public GameObject inventorySlotPrefab;

    Vector3 size = new Vector3(0.77f, 0.77f, 0.77f);

    public int inventorySpace = 6;


    public List<GameObject> inventoryList = new List<GameObject>();

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

    public void UpdateInventoryUI(GameObject inventorySlotPrefab)
    {
        //Instantiate item in Items Parent
        GameObject item = Instantiate(inventorySlotPrefab, itemsParent.transform.position, Quaternion.identity);
        item.transform.SetParent(itemsParent);

        if(item.GetComponent<InventorySlot>().isBuyabble)
        {
            inventoryList.Add(item);
            inventoryList.RemoveAll(GameObject => GameObject == null);
        }
        else if(item.GetComponent<InventorySlot>().isSellable)
        {
            inventoryList.Remove(item);
            inventoryList.RemoveAll(GameObject => GameObject == null);
        }

        item.GetComponent<InventorySlot>().isBuyabble = false;
        item.GetComponent<InventorySlot>().isSellable = true;

        item.GetComponent<RectTransform>().localScale = size;

        inventoryList.RemoveAll(GameObject => GameObject == null);
    }

    public void SpaceAlert()
    {
        GameObject alert = Instantiate(alert_space, alertPosition.position, Quaternion.identity);
        alert.transform.SetParent(alertPosition);
        Destroy(alert, 5f);
    }

    public void CostAlert()
    {
        GameObject alert = Instantiate(alert_cost, alertPosition.position, Quaternion.identity);
        alert.transform.SetParent(alertPosition);
        Destroy(alert, 5f);
    }
}
