using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopInterior;
    public GameObject gameMap;
    SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            shopInterior.SetActive(true);
            gameMap.SetActive(false);
            soundManager.PlayChickenAudio_1();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            shopInterior.SetActive(false);
            gameMap.SetActive(true);
        }
    }
}
