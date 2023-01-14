using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public GameObject houseInterior;
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
            houseInterior.SetActive(true);
            gameMap.SetActive(false);
            //soundManager.PlayChickenAudio_1();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            houseInterior.SetActive(false);
            gameMap.SetActive(true);
        }
    }
}
