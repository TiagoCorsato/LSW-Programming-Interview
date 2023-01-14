using System.Collections.Generic;
using CodeMonkey.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    public Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;

    public GameObject inventoryUI;

    private PlayerInventory playerInventory;

    public List<InventorySlot> shopList = new List<InventorySlot>();

    private void Awake()
    {

    }

    private void Start()
    {
        Hide();
    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
        inventoryUI.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        inventoryUI.SetActive(false);
    }

}
