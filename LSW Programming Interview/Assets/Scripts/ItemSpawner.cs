using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSpawner : MonoBehaviour
{
    //public List<GameObject> itemsInScene;
    public List<GameObject> itemsInScene = new List<GameObject>(new GameObject[6]);
    public List<GameObject> collectables;
    //[SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private float CooldownDuration = 5f;
    [SerializeField] private int itemsToSpawn = 6;
    [SerializeField] private TextMeshPro timerText;

    void Update()
    {
        timerText.text = CooldownDuration.ToString();
        if(itemsInScene.Count <= 0)
        {
            itemsInScene.RemoveAll(GameObject => GameObject == null);
            timerText.enabled = true;
            StartCoroutine(Cooldown());
        }

        itemsInScene.RemoveAll(GameObject => GameObject == null);
    }

    private void SpawnItems()
    {
        for(int i =0; i < itemsToSpawn; i++)
        {
            StopCoroutine(Cooldown());
            GameObject randomItem = collectables[Random.Range(0,collectables.Count)];
            //Vector2 randomSpawnPosition = new Vector2(Random.Range(-10, 11), Random.Range(-10, 11));
            GameObject spawnedItem = Instantiate(randomItem, transform.position, Quaternion.identity);
            spawnedItem.transform.SetParent(this.transform);
            itemsInScene.RemoveAll(GameObject => GameObject == null);
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(5f);
        timerText.enabled = false;
        //Spawn
        SpawnItems();
        itemsInScene.RemoveAll(GameObject => GameObject == null);

    }
}
