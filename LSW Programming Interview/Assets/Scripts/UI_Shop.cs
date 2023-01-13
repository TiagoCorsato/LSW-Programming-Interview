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

    private PlayerInventory playerInventory;

    public List<InventorySlot> shopList = new List<InventorySlot>();

    private void Awake()
    {
        //container = transform.Find("container");
        //shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        /*CreateItemButton(Item.ItemType.clownOutfit, Item.GetSprite(Item.ItemType.clownOutfit),
                "Clown Outfit", Item.GetCost(Item.ItemType.clownOutfit), 0);

        CreateItemButton(Item.ItemType.spookyOutfit, Item.GetSprite(Item.ItemType.spookyOutfit),
                "Spooky Outfit", Item.GetCost(Item.ItemType.spookyOutfit), 3);

        CreateItemButton(Item.ItemType.witchOutfit, Item.GetSprite(Item.ItemType.witchOutfit),
                "Witch Outfit", Item.GetCost(Item.ItemType.witchOutfit), 6);*/


        foreach(InventorySlot item in shopList)
        {
            item.GetComponent<Button_UI>().ClickFunc = () => {
                ;
            };
        }

        Hide();
    }

    private void CreateItemButton(Item.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        shopItemTransform.gameObject.SetActive(true);

        float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("itemCost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () => {
            TryBuyItem(itemType);
        };
    }

    private void TryBuyItem(Item.ItemType itemType)
    {
        if(shopCustomer.TrySpendGoldAmount(Item.GetCost(itemType)))
        {
            shopCustomer.BoughtItem(itemType);
        }
        else
        {
            //Cant afford it!
        }
    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
