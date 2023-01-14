using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Collectable : MonoBehaviour
{
    PlayerInventory playerInventory;
    ItemSpawner itemSpawner;

    public GameObject slotPrefab;

    SoundManager soundManager;

    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    public void ColectItem()
    {
        soundManager.PlayCollectAudio_1();
        playerInventory.UpdateInventoryUI(slotPrefab);
        Destroy(this.gameObject);
    }
}
