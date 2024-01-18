
using System.Collections;
using UnityEngine;

public class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float delayStart;
    [SerializeField] private float delaySpawn;
    [SerializeField] private int poolCoin;
    [SerializeField] private float resetDrop;

    private int coinSpawned=0;

    private void Start()
    {
        InvokeRepeating(nameof(CoinDrop), delayStart, delaySpawn);
    }
    void CoinDrop()
    {   
        { 
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
            coinSpawned++;
            if (coinSpawned>=poolCoin)
            {
                CancelInvoke("CoinDrop");
                Invoke("RestartSpawn",resetDrop);
            }
        }
    }
    void RestartSpawn()
    {
        coinSpawned=0;
        InvokeRepeating("CoinDrop",delayStart,delaySpawn);
    }
}