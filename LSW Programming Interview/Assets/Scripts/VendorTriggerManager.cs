using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorTriggerManager : MonoBehaviour
{
    [SerializeField] private UI_Shop uiShop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IShopCustomer shopCustomer = collision.GetComponent<IShopCustomer>();
        if(shopCustomer != null | collision.CompareTag("Player"))
        {
            uiShop.Show(shopCustomer);
            uiShop.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IShopCustomer shopCustomer = collision.GetComponent<IShopCustomer>();
        if(shopCustomer != null | collision.CompareTag("Player"))
        {
            uiShop.Hide();
            uiShop.gameObject.SetActive(false);
        }
    }
}
