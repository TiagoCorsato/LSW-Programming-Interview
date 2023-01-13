using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType {bird, rock, flower, clownOutfit, spookyOutfit, witchOutfit}

    void Update()
    {

    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.clownOutfit:      return 30;
            case ItemType.spookyOutfit:      return 60;
            case ItemType.witchOutfit:      return 80;
        }
    }

    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.clownOutfit:      return GameAssets.i.s_clownOutfit;
            case ItemType.spookyOutfit:      return GameAssets.i.s_spookyOutfit;
            case ItemType.witchOutfit:      return GameAssets.i.s_witchOutfit;
        }
    }
}
