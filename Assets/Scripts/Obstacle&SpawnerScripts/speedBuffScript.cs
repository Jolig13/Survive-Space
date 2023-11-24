using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuffScript : MonoBehaviour
{
    [SerializeField] private GameObject buffPrefab;
    [SerializeField] private float spawnTime;
    private void Start()
    {
        StartCoroutine(SpawnerSpeedUp());
    }
    IEnumerator SpawnerSpeedUp()
    {    
        while(true)
        {
            Debug.Log("Objeto Instanciado");       
            GameObject gameObject= Instantiate(buffPrefab,transform.position,Quaternion.identity); 
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
