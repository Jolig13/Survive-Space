using System.Collections;
using UnityEngine;

public class spawnitemScript : MonoBehaviour
{
    [SerializeField] private GameObject[] buffPrefab;
    [SerializeField] private float spawnTime;
    [SerializeField] private float minWidthy;  
    [SerializeField] private float maxWidthy;
    [SerializeField] private float waitForSpawn;
    private void Start()
    {
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(waitForSpawn);
        while (true)
        {
            var buff=Random.Range(minWidthy,maxWidthy);
            var spawnPosition=new Vector2(transform.position.x,buff);
            GameObject gameObject= Instantiate(buffPrefab[Random.Range(0,buffPrefab.Length)],spawnPosition,Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
