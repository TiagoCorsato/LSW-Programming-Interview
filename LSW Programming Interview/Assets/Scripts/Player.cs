using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int goldAmount;

    public TextMeshProUGUI goldText;

    public Animator anim;

    void Update()
    {
        goldText.text = goldAmount.ToString();
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

    public void PickUpAnimation()
    {
        anim.Play("player_PickUp");
    }
}
