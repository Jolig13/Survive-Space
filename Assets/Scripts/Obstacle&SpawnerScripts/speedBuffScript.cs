using System.Collections;
using UnityEngine;

public class SpeedBuffScript : MonoBehaviour
{
    [SerializeField] private GameObject buffPrefab;
    [SerializeField] private float spawnTime;
    [SerializeField] private float delay;
    private void Start()
    {
        StartCoroutine(SpawnerSpeedUp());
    }
    IEnumerator SpawnerSpeedUp()
    {   
        yield return new WaitForSeconds(delay);
        while(true)
        {
            //Debug.Log("Objeto Instanciado");       
            GameObject gameObject= Instantiate(buffPrefab,transform.position,Quaternion.identity); 
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
