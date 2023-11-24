using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{   
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform rayshootPoint1;
    [SerializeField] private Transform rayshootPoint2;
    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private GameObject shootRayprefab;
    [SerializeField] private int Proyectilepool;
    [SerializeField] private int shootRaypool;
    [SerializeField] private float timeWaitshoot;
    [SerializeField] private float rayTimewait;
    private void OnTriggerEnter2D(Collider2D trigger) 
    {
        if (trigger.gameObject.CompareTag("boostShoot"))
        {   
            StartCoroutine(Bettershoot(shootRaypool,rayTimewait));
            Destroy(trigger.gameObject);
        } 
        if (trigger.gameObject.CompareTag("boostShoot1"))
        {   
            StartCoroutine(Proyectile(Proyectilepool,timeWaitshoot));
            Destroy(trigger.gameObject);
        } 
    }

    IEnumerator Bettershoot(int shootRay, float rayTimewait)
    {     
        for (int i = 0; i < shootRay; i++)
        {           
            Instantiate(shootRayprefab,rayshootPoint1.position,Quaternion.identity);
            Instantiate(shootRayprefab,rayshootPoint2.position,Quaternion.identity);
            AudioManager.AudioInstance.RaySound();
            yield return new WaitForSeconds(rayTimewait);
        }          
    }
    IEnumerator Proyectile(int Proyectilepool,float timeWaitshoot)
    {
        for (int i = 0; i < Proyectilepool; i++)
        {           
            Instantiate(shootPrefab,shootPoint.position,Quaternion.identity);
            AudioManager.AudioInstance.LaserSound();
            yield return new WaitForSeconds(timeWaitshoot);
        } 
    }
}
