using CodeMonkey.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item1 item;

    public TextMeshProUGUI itemName;
    public Image itemSprite;
    public GameObject itemCost;

    //public GameObject inventorySlotPrefab;

    public bool isBuyabble;
    public bool isSellable;

    Player player;
    PlayerInventory playerInventory;
    UI_Shop uiShop;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerInventory = FindObjectOfType<PlayerInventory>();
        uiShop = FindObjectOfType<UI_Shop>();
    }

    void Update()
    {
        if(itemName.GetComponent<TextMeshProUGUI>() != null)
        {
            Debug.Log("Tem texto!");
        }

        //itemName.text = item.itemName.ToString();
        itemSprite.sprite = item.itemSprite;
        item.itemCost = int.Parse(itemCost.GetComponent<TextMeshProUGUI>().text);


        if(isBuyabble)
        {
            this.GetComponent<Button_UI>().ClickFunc = () => Buy();
        }
        else if(isSellable)
        {
            this.GetComponent<Button_UI>().ClickFunc = () => Sell();
        }
    }

    public void Buy()
    {
        if(player.goldAmount >= item.itemCost)
        {
            player.goldAmount = player.goldAmount - item.itemCost;
            playerInventory.inventoryList.Add(this);
            playerInventory.UpdateInventoryUI(this.gameObject);
            uiShop.shopList.Remove(this);
        }
    }

    public void Sell()
    {
        playerInventory.inventoryList.Remove(this);
        uiShop.shopList.Add(this);
        player.goldAmount = player.goldAmount + item.itemCost;
        Destroy(this.gameObject);
    }
}
