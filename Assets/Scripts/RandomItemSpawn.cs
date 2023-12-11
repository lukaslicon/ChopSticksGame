using System.Collections;
using TMPro;
using UnityEngine;

using UnityEngine.UI;


public class RandomItemSpawn : MonoBehaviour
{
    public ScoreUI scoreUI;
    public GameObject[] itemPrefabs; // Array of prefabs to spawn
    public Transform spawnPoint; // Specific spawn point

    public Button nextButton;

    void Start()
    {
        nextButton.onClick.AddListener(spawnItem);

    }

    void spawnItem()
    {
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        Instantiate(itemPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
        scoreUI.UpdateScore(1);
    }

}
