using CodeMonkey.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public bool clown, spooky, witch;

    public Item1 item;

    public TextMeshProUGUI itemName;
    public Image itemSprite;
    public GameObject itemCost;

    public GameObject wearButton;

    public Button_UI buyButton;

    //public GameObject inventorySlotPrefab;

    public bool isBuyabble;
    public bool isSellable;

    public bool isClothes;

    Player player;
    PlayerInventory playerInventory;
    UI_Shop uiShop;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerInventory = FindObjectOfType<PlayerInventory>();
        uiShop = FindObjectOfType<UI_Shop>();

        //buyButton.gameObject.SetActive(false);
        wearButton.SetActive(false);
    }

    void Update()
    {
        itemName.text = item.itemName;
        itemSprite.sprite = item.itemSprite;
        itemCost.GetComponent<TextMeshProUGUI>().text = item.itemCost.ToString();

        if(uiShop.gameObject.activeSelf)
        {
            //buyButton.gameObject.SetActive(true);
        }
        else
        {
            //buyButton.gameObject.SetActive(false);
        }

        if(isBuyabble)
        {
            buyButton.ClickFunc = () => Buy();
        }
        else if(isSellable)
        {
            buyButton.ClickFunc = () => Sell();
        }

        if(isSellable && isClothes)
        {
            wearButton.SetActive(true);
        }
        else
        {
            wearButton.SetActive(false);
        }
    }

    public void Buy()
    {
        if(player.goldAmount >= item.itemCost)
        {
            player.goldAmount = player.goldAmount - item.itemCost;
            playerInventory.inventoryList.Add(this);
            playerInventory.UpdateInventoryUI(this.gameObject);
        }
    }

    public void Sell()
    {
        playerInventory.inventoryList.Remove(this);
        player.goldAmount = player.goldAmount + item.itemCost;
        Destroy(this.gameObject);
    }

    public void WearClothing()
    {
        //Wear clothes
        Debug.Log("Im wearing cholthes");

        foreach (GameObject clothing in playerInventory.clothesList)
        {
            if(clown && clothing.name == "clown_outfit")
            {
                for (var i = 0; i < playerInventory.clothesList.Count; i++)
                {
                    playerInventory.clothesList[i].gameObject.SetActive(false);
                    playerInventory.blackBox.SetActive(false);
                }
                clothing.SetActive(true);
            }

            if(spooky && clothing.name == "spooky_outfit")
            {

                for (var i = 0; i < playerInventory.clothesList.Count; i++)
                {
                    playerInventory.clothesList[i].gameObject.SetActive(false);
                    playerInventory.blackBox.SetActive(false);
                }
                clothing.SetActive(true);
            }

            if(witch && clothing.name == "witch_outfit")
            {

                for (var i = 0; i < playerInventory.clothesList.Count; i++)
                {
                    playerInventory.clothesList[i].gameObject.SetActive(false);
                    playerInventory.blackBox.SetActive(false);
                }
                clothing.SetActive(true);
            }
        }
    }
}
