using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObstacle : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnTime;
    [SerializeField] private float minWidthy;  
    [SerializeField] private float maxWidthy;
    private void Start()
    {
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        while (true)
        {
            var meteor=Random.Range(minWidthy,maxWidthy);
            var spawnPosition=new Vector2(transform.position.x,meteor);
            GameObject gameObject= Instantiate(obstaclePrefab,spawnPosition,Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
