using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IShopCustomer
{
    public int goldAmount;

    public TextMeshProUGUI goldText;

    public void BoughtItem(Item.ItemType itemType)
    {
        Debug.Log("Bought item: " + itemType);
    }

    public bool TrySpendGoldAmount(int spendGoldAmount)
    {
        if(goldAmount >= spendGoldAmount)
        {
            goldAmount -= spendGoldAmount;
            return true;
        }
        else
        {
            return false;
        }
    }
}
