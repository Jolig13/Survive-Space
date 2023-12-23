
using System.Collections;
using UnityEngine;

public class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float delayStart;
    [SerializeField] private float delaySpawn;
    [SerializeField] private int poolCoin;
    [SerializeField] private float resetDrop;
    [SerializeField] private float maxWidth;
    [SerializeField] private float minWidth;
    private int coinSpawned=0;

    private void Start()
    {
        InvokeRepeating(nameof(CoinDrop), delayStart, delaySpawn);
    }
    void CoinDrop()
    {   
        {   
            var coinSpawn= Random.Range(maxWidth,minWidth);
            var positionDrop= new Vector2(transform.position.x, coinSpawn);
            Instantiate(coinPrefab, positionDrop, Quaternion.identity);
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