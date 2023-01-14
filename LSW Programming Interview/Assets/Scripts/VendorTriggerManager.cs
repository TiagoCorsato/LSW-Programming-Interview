using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorTriggerManager : MonoBehaviour
{
    [SerializeField] private UI_Shop uiShop;

    public GameObject emote;

    void Start()
    {
        emote.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            uiShop.Show();
            uiShop.gameObject.SetActive(true);
            emote.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            uiShop.Hide();
            uiShop.gameObject.SetActive(false);
            emote.SetActive(false);
        }
    }
}
